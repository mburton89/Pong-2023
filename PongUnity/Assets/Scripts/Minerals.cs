using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    public List<GameObject> worms;
    public string mineralType;
    public GameManager gameManager;
    public int pointValue = 1;

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

                GameManager.Instance.UpdateMineralCountUI();

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
