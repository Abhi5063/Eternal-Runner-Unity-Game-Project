using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText; // Display for the main score
    public Text scoreText1; // Another display for the score

    private int score = 0;

    private void Awake()
    {
        // Ensure there is only one instance of the ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreTexts();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreTexts();
    }

    public void SetGameOver()
    {
        // Update both score texts for game over screen
        scoreText.text = "Final Score: " + score;
        scoreText1.text = "Final Score: " + score;
    }

    private void UpdateScoreTexts()
    {
        scoreText.text = "Score: " + score;
        scoreText1.text = "Score: " + score;
    }
}
