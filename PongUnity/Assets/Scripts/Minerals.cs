using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    public List<GameObject> worms;

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
            takeDamage();
          //Debug.Log("Update called");
        }
    }

    public void takeDamage()
    {
        currentHealth -= 1;
      //Debug.Log("Current Health: " + currentHealth);
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
          //Debug.Log("Mineral destroyed!");
            Destroy(this.gameObject);
        }
    }


}
