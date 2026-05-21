using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [Header("UI Панелі")]
    public GameObject mainMenuPanel;
    public GameObject gameHUD;

    void Awake()
    {
        Time.timeScale = 0f;

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (gameHUD != null)
            gameHUD.SetActive(false);
    }

    public void StartPvEGame()
    {
        Debug.Log("Запуск режиму: PvE (Захисник vs ШІ)");
        LaunchGame();
    }

    public void StartPvPGame()
    {
        Debug.Log("Запуск режиму: PvP (Hot-seat)");
        LaunchGame();
    }

    private void LaunchGame()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (gameHUD != null)
            gameHUD.SetActive(true);

        MusicManager musicManager = FindObjectOfType<MusicManager>();

        if (musicManager != null)
        {
            musicManager.SetGameVolume();
        }

        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Вихід з гри");
        Application.Quit();
    }
}