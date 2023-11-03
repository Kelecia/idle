using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCacti : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public CowSpawner cowSpawner;
    public int upgradeCost = 2;
    public GameObject upgradedPrefab;
    private List<Transform> usedUpgradeSpawnPoints = new List<Transform>(); // List of used spawn points for upgraded objects

    public string playerTag = "Player";

    private GameObject[] playersToUpgrade;
    private int currentIndex = 0;
    private bool isUpgrading = false;

    public void OnButtonClick()
    {
        if (!isUpgrading && CoinCounter.instance.currentCoins >= upgradeCost)
        {
            CoinCounter.instance.IncreaseCoins(-upgradeCost); // Deduct the cost from the player's coins
            playersToUpgrade = GameObject.FindGameObjectsWithTag(playerTag);
            if (playersToUpgrade.Length > 0)
            {
                StartCoroutine(UpgradeNextPlayer());
                ReduceEnemySpawnInterval(); // Reduce the enemy spawning interval
            }
            else
            {
                Debug.Log("No players to upgrade.");
            }
        }
        else
        {
            Debug.Log("Not enough coins to upgrade");
        }
    }

    private void ReduceEnemySpawnInterval()
    {
        // Call the AdjustEnemyInterval method in the EnemySpawner
        enemySpawner.AdjustEnemyInterval(1f); // Adjust to your desired interval
    }

    private IEnumerator UpgradeNextPlayer()
    {
        isUpgrading = true;
        GameObject playerToUpgrade = playersToUpgrade[currentIndex];
        Transform spawnPoint = FindUnusedSpawnPoint();
        if (spawnPoint != null)
        {
            Vector3 spawnPosition = spawnPoint.position;

            // Delay before replacing the player
            yield return new WaitForSeconds(0.1f);

            // Instantiate upgraded game object 
            Instantiate(upgradedPrefab, spawnPosition, Quaternion.identity);
            usedUpgradeSpawnPoints.Add(spawnPoint); // Mark the spawn point used for upgraded objects

            // Delay before destroying the player
            yield return new WaitForSeconds(0.1f);
            Destroy(playerToUpgrade); // Destroy the existing player

            currentIndex++;

            if (currentIndex >= playersToUpgrade.Length)
            {
                Debug.Log("All players have been upgraded.");
                currentIndex = 0; // Reset the index for future upgrades
            }

            isUpgrading = false;
        }
        else
        {
            Debug.Log("No available spawn points for upgraded objects.");
            isUpgrading = false;
        }

        yield return null;
    }

    private Transform FindUnusedSpawnPoint()
    {
        foreach (Transform usedSpawnPoint in cowSpawner.usedSpawnPoints)
        {
            if (!usedUpgradeSpawnPoints.Contains(usedSpawnPoint))
            {
                return usedSpawnPoint;
            }
        }
        return null;
    }
}






