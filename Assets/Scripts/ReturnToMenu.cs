using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class ReturnToMenu : MonoBehaviour
{
    public PlayableDirector outroDirector;
    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        if (outroDirector != null)
            outroDirector.stopped += LoadMenu;
    }

    private void OnDisable()
    {
        if (outroDirector != null)
            outroDirector.stopped -= LoadMenu;
    }

    private void LoadMenu(PlayableDirector pd)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(menuSceneName);
    }
}