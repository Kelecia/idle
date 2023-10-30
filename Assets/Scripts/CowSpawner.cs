using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawner : MonoBehaviour
{
    public GameObject cowPrefab;
    public int cowCost = 1;

    public void OnButtonClick()
    {
        if (CoinCounter.instance.currentCoins >= cowCost)
        {
            CoinCounter.instance.IncreaseCoins(-cowCost); // Deduct the cost from the player's coins
            SpawnCow();
        }
        else
        {
            Debug.Log("Not enough coins to spawn a cow");
        }
    }

    private void SpawnCow()
    {
        Instantiate(cowPrefab, transform.position, Quaternion.identity); // Spawn the cow prefab
    }

}
