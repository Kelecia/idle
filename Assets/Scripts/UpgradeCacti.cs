using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCacti : MonoBehaviour
{
    
    
        public CowSpawner cowSpawner;
        public int upgradeCost = 2;
        public GameObject upgradedPrefab;
        private List<Transform> usedUpgradeSpawnPoints = new List<Transform>(); // List of used spawn points for upgraded objects

        public string playerTag = "Player";

        public void OnButtonClick()
        {
            if (CoinCounter.instance.currentCoins >= upgradeCost)
            {
                CoinCounter.instance.IncreaseCoins(-upgradeCost); // Deduct the cost from the player's coins
                ReplacePlayersWithUpgradedObject();
            }
            else
            {
                Debug.Log("Not enough coins to upgrade");
            }
        }

        private void ReplacePlayersWithUpgradedObject()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
            if (cowSpawner.spawnPoints.Length > 0)
            {
                // Destroy the existing players
                foreach (GameObject player in players)
                {
                    Destroy(player);
                }

                // Now, you can instantiate your upgraded game object in place of the players
                // Ensure that upgraded objects do not spawn at the same location as other upgraded objects
                foreach (Transform usedSpawnPoint in cowSpawner.usedSpawnPoints)
                {
                    if (!usedUpgradeSpawnPoints.Contains(usedSpawnPoint))
                    {
                        Vector3 spawnPosition = usedSpawnPoint.position;
                        // Instantiate your upgraded game object here
                        Instantiate(upgradedPrefab, spawnPosition, Quaternion.identity);
                        usedUpgradeSpawnPoints.Add(usedSpawnPoint); // Mark the spawn point as used for upgraded objects
                    }
                }
            }
        }
    
}



