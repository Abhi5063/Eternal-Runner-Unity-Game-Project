using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameoverPanel;

    void Start()
    {
        gameOver = false;
        gameoverPanel.SetActive(false); // Ensure the game over panel is hidden at the start
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0; // Pause the game
            gameoverPanel.SetActive(true); // Show the game over panel
        }
    }

    public static void TriggerGameOver()
    {
        gameOver = true;
    }
}