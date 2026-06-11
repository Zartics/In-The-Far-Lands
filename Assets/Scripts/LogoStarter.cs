using System.Collections; // Бібліотека для роботи з корутинами
using UnityEngine;
using UnityEngine.SceneManagement;

// Головний клас для роботи екрану завантаження
public class SplashManager : MonoBehaviour
{
    [Header("Налаштування")]
    public CanvasGroup logoGroup;
    public float fadeSpeed = 0.4f;
    public float waitTime = 3f;

    void Start()
    {
        logoGroup.alpha = 0;
        StartCoroutine(PlaySplash());
    }

    // Функція, яка вміє розтягувати своє виконання в часі
    IEnumerator PlaySplash()
    {
        // Поки alpha < 1 прозорість збільшується
        while (logoGroup.alpha < 1)
        {
            logoGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        // Очікування таймера
        yield return new WaitForSeconds(waitTime);

        // Поки alpha > 0 прозорість зменшується
        while (logoGroup.alpha > 0)
        {
            logoGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}