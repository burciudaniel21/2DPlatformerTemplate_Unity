using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int playerHealth = 100;
    public int playerScore = 0;

    // TMP text elements for health, score, and win message
    public TMP_Text healthText;
    public TMP_Text scoreText;
    public TMP_Text winText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // If another instance exists, destroy it
        }
    }

    private void Start()
    {
        UpdateHealthDisplay();
        UpdateScoreDisplay();
        winText.gameObject.SetActive(false); // Hide the win message initially
    }

    public void UpdateHealth(int amount)
    {
        playerHealth += amount;
        if (playerHealth <= 0)
        {
            RestartGame();
        }

        UpdateHealthDisplay();
    }

    public void UpdateScore(int amount)
    {
        playerScore += amount;
        UpdateScoreDisplay();
    }

    private void UpdateHealthDisplay()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + playerHealth.ToString();
        }
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + playerScore.ToString();
        }
    }

    public void PlayerWins()
    {
        // Show the win message
        if (winText != null)
        {
            winText.gameObject.SetActive(true);
            winText.text = "You Win!";
        }

        // Freeze the game
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Make sure time is running again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Reset player health and score to their default values
        playerHealth = 100;
        playerScore = 0;

        // Update UI after reset
        UpdateHealthDisplay();
        UpdateScoreDisplay();
    }
}
