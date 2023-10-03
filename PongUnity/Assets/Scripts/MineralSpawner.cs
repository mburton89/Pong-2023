using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralSpawner : MonoBehaviour
{
    public float gridSize = 10;
    public float mineralYPosition = 1;

    //FOR LOOPS
    public GameObject mineralPrefab;
    public int numItemsToSpawn = 20;

    //FOREACH
    public List<GameObject> mineralPrefabs;

    private void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        for (int i = 0; i < numItemsToSpawn; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-gridSize, gridSize), mineralYPosition, Random.Range(-gridSize, gridSize));
            Instantiate(mineralPrefab, randomPosition, Quaternion.identity);
        }
    }
}
