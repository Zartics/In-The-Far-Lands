using System.Collections;
using UnityEngine;

// Головний клас для плавного зникнення титрів
public class GhostCredits : MonoBehaviour
{
    [Header("Налаштування")]
    public CanvasGroup creditsGroup;
    public float fadeSpeed = 0.5f;

    private bool isFading = false;

    // Функція зникнення, що спрацьовує, якщо саме гравець доторкнеться колайдера
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFading)
        {
            isFading = true;
            StartCoroutine(FadeOutText());
        }
    }

    // Корутина для плавного зниження прозорості
    IEnumerator FadeOutText()
    {
        while (creditsGroup.alpha > 0)
        {
            creditsGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        creditsGroup.gameObject.SetActive(false);
    }
}
