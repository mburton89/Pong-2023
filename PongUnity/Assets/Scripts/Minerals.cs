using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    public string mineralType;
    public GameManager gameManager;
    public int pointValue = 1;

    public GameObject chunkPrefab;
    public GameObject wormPrefab;
    public int chunksToSpawn;
    public int wormsToSpawn;

    private void Awake()
    {
        maxHealth = 10;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TakeDamage();
            //Debug.Log("Update called");
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
      //Debug.Log("Current Health: " + currentHealth);
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        //Debug.Log("Current Health: " + currentHealth);
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            GameManager.Instance.UpdateMineralCountUI();
         
                if (mineralType == "Mineral 1")
                {
                    GameManager.Instance.mineral1Count += pointValue;
                }
                else if (mineralType == "Mineral 2")
                {
                GameManager.Instance.mineral2Count += pointValue;
                }
                else if (mineralType == "Mineral 3")
                {
                GameManager.Instance.mineral3Count += pointValue;
                }
                else if (mineralType == "Mineral 4")
                {
                GameManager.Instance.mineral4Count += pointValue;
                }

            GameManager.Instance.UpdateMineralCountUI();

            for (int i = 0; i < chunksToSpawn; i++)
            {
                GameObject chunk = Instantiate(chunkPrefab, transform.position, Quaternion.identity, null);

                float chunkForce = 30;

                float randX = Random.Range(-chunkForce, chunkForce);
                float randZ = Random.Range(-chunkForce, chunkForce);
                Vector3 newForce = new Vector3 (randX, chunkForce, randZ);

                chunk.GetComponent<Rigidbody>().AddForce(newForce);
            }

            for (int i = 0; i < wormsToSpawn; i++)
            {
                GameObject worm = Instantiate(wormPrefab, transform.position, Quaternion.identity, null);

                float chunkForce = 30;

                float randX = Random.Range(-chunkForce, chunkForce);
                float randZ = Random.Range(-chunkForce, chunkForce);
                Vector3 newForce = new Vector3(randX, chunkForce, randZ);

                worm.GetComponent<Rigidbody>().AddForce(newForce);
            }

            //Debug.Log("Mineral destroyed!");
            Destroy(this.gameObject);
        }
    }

    public GameObject particlePrefab;
    void OnDestroy()
    {
        if (particlePrefab != null)
        {
            Instantiate(particlePrefab, transform.position, Quaternion.identity);
        }
    }

}
