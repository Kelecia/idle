using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCacti : MonoBehaviour
{
    public CowSpawner cowSpawner;

    public GameObject upgradedPrefab;

    public void OnButtonClick()
    {
        if (CoinCounter.instance.currentCoins >= cowCost)
        {
            CoinCounter.instance.IncreaseCoins(-cowCost); // Deduct the cost from the player's coins
            ReplaceCowsWithUpgradedObject();
        }
        else
        {
            Debug.Log("Not enough coins to upgrade");
        }
    }


    private void ReplaceCowsWithUpgradedObject()
    {
        if (spawnPoints.Length > 0)
        {
            // Here, you can destroy the existing cows spawned by the CowSpawner script
            foreach (Transform usedSpawnPoint in cowSpawner.usedSpawnPoints)
            {
                Destroy(usedSpawnPoint.gameObject);
            }

            // Now, you can instantiate your upgraded game object in place of the cows
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



