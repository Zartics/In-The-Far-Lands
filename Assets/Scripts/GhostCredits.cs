using System.Collections;
using UnityEngine;

public class GhostCredits : MonoBehaviour
{
    [Header("Налаштування")]
    public CanvasGroup creditsGroup;
    public float fadeSpeed = 0.5f;

    private bool isFading = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFading)
        {
            isFading = true;
            StartCoroutine(FadeOutText());
        }
    }

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
