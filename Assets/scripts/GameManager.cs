using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
using TMPro;
=======
using UnityEngine.SceneManagement; // ОБОВ'ЯЗКОВО: дозволяє перезавантажувати рівень
>>>>>>> 6233c5f4735fd79c7a5d4e067bdbff7ccd940b41

public class GameManager : MonoBehaviour
{
    [Header("Налаштування об'єктів")]
<<<<<<< HEAD
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
=======
    public BaseHealth baseHealth;  // Сюди тягнемо об'єкт Base
    public GameObject gameOverUI;  // Сюди тягнемо GameOverPanel

    private bool isGameOver = false;

    void Update()
    {
        // Якщо гра вже закінчена, нічого не робимо
        if (isGameOver) return;

        // Перевіряємо, чи здоров'я бази впало до нуля
        if (baseHealth != null && baseHealth.GetCurrentHealth() <= 0)
        {
            ShowGameOver();
>>>>>>> 6233c5f4735fd79c7a5d4e067bdbff7ccd940b41
        }
    }

    void ShowGameOver()
    {
        isGameOver = true;
<<<<<<< HEAD

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

=======
        
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Вмикаємо панель програшу
        }

        Time.timeScale = 0f; // Ставимо гру на паузу
    }

    // Цей метод МАЄ бути public, щоб кнопка його знайшла
    public void RestartGame()
    {
        Debug.Log("Перезапуск гри...");
        
        Time.timeScale = 1f; // ВАЖЛИВО: повертаємо час у норму, інакше нова гра буде на паузі
        
        // Завантажуємо поточну сцену заново
>>>>>>> 6233c5f4735fd79c7a5d4e067bdbff7ccd940b41
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}