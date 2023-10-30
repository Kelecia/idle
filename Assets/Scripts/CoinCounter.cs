using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TextMeshProUGUI coinText;
    public int currentCoins;
 
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinText.text = "Coins:" + currentCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "Coins:" + currentCoins.ToString();
    }

    
 
}
