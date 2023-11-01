using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWeopon : MonoBehaviour
{
    public GameObject enemy;
    public int upgradeCost = 2;
    public int damageIncrease = 3;

    public void OnButtonClick()
    {
        if (CoinCounter.instance.currentCoins >= upgradeCost)
        {
            CoinCounter.instance.IncreaseCoins(-upgradeCost); // Deduct the cost from the player's coins
            DamageIncrease();
        }
        else
        {
            Debug.Log("Not enough coins to upgrade");
        }
    }

    private void DamageIncrease()
    {
        //call the take damage function in enemyAI script
        Enemy_AI enemyAI = enemy.GetComponent<Enemy_AI>();
        if (enemyAI != null)
        {
            enemyAI.IncreaseDamage();
        }
    }
}

