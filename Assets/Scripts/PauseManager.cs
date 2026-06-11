using UnityEngine;
using UnityEngine.SceneManagement;

// Головний клас для роботи меню паузи
public class PauseManager : MonoBehaviour
{
    [Header("UI Елементи")]
    public GameObject pauseMenuUI;
    public GameObject pauseBlur;

    private bool isPaused = false;

    // Перевірка реєстрації клавіші ESC в кожному кадрі
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Вимикання видимості та фіксація позиції курсора
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Метод увімкнення паузи
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        pauseBlur.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        AudioListener.pause = true;
    }

    // Метод вимкнення паузи
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseBlur.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        AudioListener.pause = false;
    }

    // Метод виходу в Головне меню
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(1);
    }

    // Метод виходу з гри
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Вихід з гри");
        Application.Quit();
    }
}