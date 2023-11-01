using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemyInterval = 3.5f;
    public Transform[] spawnPoints;

    /*void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyInterval);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            int randomIndex = Random.Range(0, spawnPoints.Length); 
            Vector3 spawnPosition = spawnPoints[randomIndex].position;
            
        }
    }*/
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].position;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(enemyInterval);
        }
    }
}
