using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables; // Бібліотека для роботи з Timeline

// Головний клас, який повертає гравця в Головне меню після завершення катсцени
public class ReturnToMenu : MonoBehaviour
{
    public PlayableDirector outroDirector;
    public string menuSceneName = "MainMenu";

    // Викликається, коли цей об'єкт активується на сцені
    private void OnEnable()
    {
        if (outroDirector != null)
            outroDirector.stopped += LoadMenu;
    }

    // Викликається при вимкненні або знищенні об'єкта
    private void OnDisable()
    {
        if (outroDirector != null)
            outroDirector.stopped -= LoadMenu;
    }

    // Метод, який спрацьовує автоматично, коли катсцена закінчується
    private void LoadMenu(PlayableDirector pd)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(menuSceneName);
    }
}