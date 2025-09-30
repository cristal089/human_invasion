using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    List<GameObject> spawnPositions;

    [SerializeField] List<GameObject> enemyPrefabs;

    void Awake()
    {
        spawnPositions = new List<GameObject>();
        foreach (Transform child in transform)
        {
            spawnPositions.Add(child.gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 2);
    }


    void SpawnEnemy()
    {
        //A função Random.Range gera número aleatórios entre "min" e "max" (aberto). 
        int randomEnemy = Random.Range(0, enemyPrefabs.Count);
        int randomPos = Random.Range(0, spawnPositions.Count);

        Instantiate(enemyPrefabs[randomEnemy], spawnPositions[randomPos].transform.position, Quaternion.identity);
    }
}
