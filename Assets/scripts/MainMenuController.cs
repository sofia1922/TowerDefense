using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [Header("UI Панелі")]
    public GameObject mainMenuPanel; // Головна панель меню
    public GameObject gameHUD;       // Інтерфейс гри (HP, Золото)

    void Awake()
    {
        // На старті гра завжди на паузі, меню активне
        Time.timeScale = 0f;
        mainMenuPanel.SetActive(true);
        if (gameHUD != null) gameHUD.SetActive(false);
    }

    // Режим Гравець проти Комп'ютера (Обов'язково)
    public void StartPvEGame()
    {
        Debug.Log("Запуск режиму: PvE (Захисник vs ШІ)");
        LaunchGame();
    }

    // Режим Гравець проти Гравця (Бонусні бали)
    public void StartPvPGame()
    {
        Debug.Log("Запуск режиму: PvP (Hot-seat)");
        LaunchGame();
    }

    private void LaunchGame()
    {
        mainMenuPanel.SetActive(false);
        if (gameHUD != null) gameHUD.SetActive(true);
        Time.timeScale = 1f; // Запуск ігрового часу
    }

    public void QuitGame()
    {
        Debug.Log("Вихід з гри");
        Application.Quit();
    }
}