using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public GameObject cowPrefab;
    public int cowCost = 1;

    public Transform[] spawnPoints; // Array of spawn points
    public List<Transform> usedSpawnPoints = new List<Transform>(); // List of used spawn points
    

    public void OnButtonClick()
    {
        if (CoinCounter.instance.currentCoins >= cowCost)
        {
            CoinCounter.instance.IncreaseCoins(-cowCost); // Deduct the cost from the player's coins
            SpawnCow();
            ReduceEnemySpawnInterval();
        }
        else
        {
            Debug.Log("Not enough coins to spawn a cowboy");
        }
    }

    private void ReduceEnemySpawnInterval()
    {
        // Call the AdjustEnemyInterval method in the EnemySpawner
        enemySpawner.AdjustEnemyInterval(2f); // Adjust to your desired interval
    }

    private void SpawnCow()
    {
        if (spawnPoints.Length > 0)
        {
            List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);

            // Remove used spawn points from the available spawn points list
            foreach (Transform usedSpawnPoint in usedSpawnPoints)
            {
                availableSpawnPoints.Remove(usedSpawnPoint);
            }

            if (availableSpawnPoints.Count > 0)
            {
                int randomIndex = Random.Range(0, availableSpawnPoints.Count); // Choose a random spawn point
                Transform spawnPoint = availableSpawnPoints[randomIndex];
                usedSpawnPoints.Add(spawnPoint); // Mark the spawn point as used
                Vector3 spawnPosition = spawnPoint.position;
                Instantiate(cowPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.Log("No available");
            }


        }
        
    }
}
