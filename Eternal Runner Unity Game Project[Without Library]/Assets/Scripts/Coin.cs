using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // Value of the coin
    private GameObject player; // Reference to the player GameObject
    private AudioSource coinSound; // Reference to the AudioSource component

    private void Start()
    {
        // Find the player GameObject by tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Optionally, add a sound effect for collecting coins
        coinSound = GetComponent<AudioSource>();

        // Ensure player was found
        if (player == null)
        {
            Debug.LogError("Player GameObject not found. Make sure the player has the tag 'Player'.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin triggered by: " + other.gameObject.name);

        if (other.gameObject == player)
        {
            Debug.Log("Coin collected by player.");

            // Add coin value to the player's score
            ScoreManager.instance.AddScore(coinValue);

            // Play coin collection sound if it exists
            if (coinSound != null)
            {
                coinSound.Play();
            }

            // Destroy the coin GameObject
            Destroy(gameObject);
        }
    }
}
