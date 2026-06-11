using UnityEngine;
using UnityEngine.SceneManagement;

// Головний клас, який керує кнопками в меню
public class MenuController : MonoBehaviour
{
    // Метод для запуску гри (прив'язується до кнопки "Грати")
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    // Метод для виходу з гри (прив'язується до кнопки "Вихід")
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Гра закрилася");
    }
}
