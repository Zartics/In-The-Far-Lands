using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("UI Елементи")]
    public GameObject pauseMenuUI;
    public GameObject pauseBlur;

    private bool isPaused = false;

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

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Вихід з гри");
        Application.Quit();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}