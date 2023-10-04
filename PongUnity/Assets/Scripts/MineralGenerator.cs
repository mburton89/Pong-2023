using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MineralGenerator : MonoBehaviour
{
    public float gridSize = 10;
    public float mineralYPosition = 1;
    public int numberOfMineralsToSpawn = 20;
    public GameObject mineralPrefab;

    public List<GameObject> mineralPrefabs;


    void Start()
    {
        GenerateMinerals();
    }

    private void GenerateMinerals()
    {
        foreach (GameObject mineralPrefab in mineralPrefabs)
        {
            float randX = Random.Range(-gridSize, gridSize);
            float randZ = Random.Range(-gridSize, gridSize);

            Vector3 spawnPosition = new Vector3(randX, mineralYPosition, randZ);

            Instantiate(mineralPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void GenerateMinerals(int customNumberOfMineralsToSpawn)
    {
        for (int i = 0; i < customNumberOfMineralsToSpawn; i++)
        {
            Debug.LogWarning(i.ToString());

            float randX = Random.Range(-gridSize, gridSize);
            float randZ = Random.Range(-gridSize, gridSize);

            Vector3 spawnPosition = new Vector3(randX, mineralYPosition, randZ);

            Instantiate(mineralPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
