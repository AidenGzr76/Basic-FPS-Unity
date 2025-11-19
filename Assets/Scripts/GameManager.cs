using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject deathMenu;

    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 0; // اول بازی متوقف باشه
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        deathMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !startMenu.activeSelf && !deathMenu.activeSelf)
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startMenu.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowDeathMenu()
    {
        Time.timeScale = 0;
        deathMenu.SetActive(true);
    }
}
