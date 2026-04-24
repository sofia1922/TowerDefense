using UnityEngine;
using UnityEngine.SceneManagement; // ОБОВ'ЯЗКОВО: дозволяє перезавантажувати рівень

public class GameManager : MonoBehaviour
{
    [Header("Налаштування об'єктів")]
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
        }
    }

    void ShowGameOver()
    {
        isGameOver = true;
        
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}