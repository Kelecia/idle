using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemyInterval = 3.5f;
    public Transform[] spawnPoints;

    private Coroutine spawningCoroutine;

    private List<GameObject> spawnedEnemies = new List<GameObject>(); // Store references to spawned enemies

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        // Start the spawning coroutine and store the reference
        spawningCoroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].position;
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            spawnedEnemies.Add(enemy); // Store the spawned enemy reference
            yield return new WaitForSeconds(enemyInterval);
        }
    }

    // Public method to adjust the enemy spawning interval
    public void AdjustEnemyInterval(float newInterval)
    {
        enemyInterval = newInterval;

        // Stop the current spawning coroutine
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
        }

        // Start a new coroutine with the adjusted interval
        StartSpawning();
    }


    /* void Start()
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
    */
}
