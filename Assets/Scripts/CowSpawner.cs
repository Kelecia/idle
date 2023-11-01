using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public GameObject cowPrefab;
    public int cowCost = 1;

    //public float Radius = 1;

    public Transform[] spawnPoints; // Array of spawn points
    private List<Transform> usedSpawnPoints = new List<Transform>(); // List of used spawn points

    public void OnButtonClick()
    {
        if (CoinCounter.instance.currentCoins >= cowCost)
        {
            CoinCounter.instance.IncreaseCoins(-cowCost); // Deduct the cost from the player's coins
            SpawnCow();
        }
        else
        {
            Debug.Log("Not enough coins to spawn a cowboy");
        }
    }


    private void SpawnCow()
    {
        if (spawnPoints.Length > 0)
        {
            //int randomIndex = Random.Range(0, spawnPoints.Length); // Choose a random spawn point
            //Vector3 spawnPosition = spawnPoints[randomIndex].position;
            //Instantiate(cowPrefab, spawnPosition, Quaternion.identity);

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
        //Instantiate(cowPrefab, transform.position, Quaternion.identity); // Spawn the cow prefab
        //Vector3 randomPos = Random.insideUnitCircle * Radius;
        //Instantiate(cowPrefab, randomPos, Quaternion.identity);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
       Gizmos.DrawWireSphere(this.transform.position, Radius);
    }*/

}
