using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance { get; private set; }
    public GameObject gameOverUI; // Reference to the game over UI panel

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void TriggerGameOver()
    {
        // Show game over UI
        gameOverUI.SetActive(true);
    }
}
