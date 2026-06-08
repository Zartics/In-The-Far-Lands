using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    IEnumerator PlaySplash()
    {
        while (logoGroup.alpha < 1)
        {
            logoGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        while (logoGroup.alpha > 0)
        {
            logoGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
        SceneManager.LoadScene(1);
    }
}