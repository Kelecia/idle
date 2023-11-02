using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasToggle : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    public int emotionalSuportCost = 1;
    public GameObject canvasObject; // Reference to the Canvas GameObject to toggle.
    public TMP_Text textComponent; // Reference to the TextMeshPro Text component.

    private bool isCanvasActive = true; // Initially, set to true to activate the Canvas.

    private string[] textOptions = { "You're doing great !", "Well Done !", "Proud of You !", "Amazing!" };
    private int currentTextIndex = 0;

    public void OnButtonClick()
    {
        if (CoinCounter.instance.currentCoins >= emotionalSuportCost)
        {
            CoinCounter.instance.IncreaseCoins(-emotionalSuportCost); // Deduct the cost from the player's coins
            ToggleCanvas();
            ReduceEnemySpawnInterval();
        }
        else
        {
            Debug.Log("Not enough for emotional support");
        }
    }

    private void ReduceEnemySpawnInterval()
    {
        // Call the AdjustEnemyInterval method in the EnemySpawner
        enemySpawner.AdjustEnemyInterval(3f); // Adjust to your desired interval
    }

    public void ToggleCanvas()
    {
        isCanvasActive = !isCanvasActive;
        canvasObject.SetActive(isCanvasActive);

        if (isCanvasActive)
        {
            // Display the next text when the Canvas is activated.
            textComponent.text = textOptions[currentTextIndex];
            currentTextIndex = (currentTextIndex + 1) % textOptions.Length;
        }

    }
}
