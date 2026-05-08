using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Налаштування об'єктів")]
    public BaseHealth baseHealth;
    public GameObject gameOverUI;

    [Header("Win")]
    public GameObject winUI;

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        // ПРОГРАШ
        if (baseHealth != null && baseHealth.GetCurrentHealth() <= 0)
        {
            ShowGameOver();
            return;
        }

        // ПЕРЕМОГА
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        WaveSpawner spawner = FindObjectOfType<WaveSpawner>();

        if (spawner == null) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Якщо хвиля закінчена і ворогів нема
        if (spawner.IsWaveComplete() && enemies.Length == 0)
        {
            ShowWin();
        }
    }

    void ShowGameOver()
    {
        isGameOver = true;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    void ShowWin()
    {
        isGameOver = true;

        if (winUI != null)
        {
            winUI.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}