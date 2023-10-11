using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaclespawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Assign your obstacle prefab in the Inspector
    public float spawnRate = 2.0f; // Adjust the spawn rate as needed
    public float spawnRadius = 5.0f; // Adjust the spawn radius as needed

    void Start()
    {
        // Call the SpawnObstacle method repeatedly based on spawnRate
        InvokeRepeating("SpawnObstacle", 0.0f, spawnRate);
    }

    void SpawnObstacle()
    {
        // Generate a random position within the spawnRadius
        Vector3 randomPosition = Random.insideUnitCircle * spawnRadius;
        randomPosition.z = 0; // Set the z-coordinate to match your game

        // Instantiate the obstacle at the random position
        Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);
    }
}