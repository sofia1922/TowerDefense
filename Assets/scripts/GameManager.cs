using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Налаштування об'єктів")]
    public BaseHealth baseHealth;
    public GameObject gameOverUI;

    [Header("Win")]
    public GameObject winUI;

    [Header("Gold")]
    public int currentGold = 300;
    public TMP_Text goldText;

    private bool isGameOver = false;

    void Start()
    {
        UpdateGoldUI();
    }

    void Update()
    {
        if (isGameOver)
            return;

        if (baseHealth != null && baseHealth.GetCurrentHealth() <= 0)
        {
            ShowGameOver();
            return;
        }

        CheckWinCondition();
    }



    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldUI();
    }

    public void SpendGold(int amount)
    {
        currentGold -= amount;

        if (currentGold < 0)
        {
            currentGold = 0;
        }

        UpdateGoldUI();
    }

    void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + currentGold;
        }
    }



    void CheckWinCondition()
    {
        WaveSpawner spawner = FindObjectOfType<WaveSpawner>();

        if (spawner == null)
            return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

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