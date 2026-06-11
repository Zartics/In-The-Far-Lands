using UnityEngine;
using UnityEngine.Playables; // Бібліотека для роботи з Timeline
using UnityEngine.EventSystems; // Бібліотека для розпізнавання кліків по UIы
using System.Collections;

// Головний клас для пропускання ключових кадрів та паузи катсцен
public class TimelineSkipper : MonoBehaviour
{
    [Header("Налаштування")]
    public PlayableDirector director;
    public int[] frameCheckpoints;
    public float timelineFPS = 60f;

    [Header("UI Індикатор")]
    public CanvasGroup skipIcon;
    public float dimAlpha = 0.3f;

    private bool isTimelinePausedByMenu = false;

    void Update()
    {
        // Логіка роботи паузи катсцени
        if (director != null)
        {
            if (Time.timeScale == 0f && !isTimelinePausedByMenu && director.state == PlayState.Playing)
            {
                director.Pause();
                isTimelinePausedByMenu = true;
            }

            else if (Time.timeScale > 0f && isTimelinePausedByMenu)
            {
                director.Play();
                isTimelinePausedByMenu = false;
            }
        }

        // Логіка роботи пропускання катсцени
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale == 0f) return;
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

            if (director != null && director.state == PlayState.Playing)
            {
                SkipToNextPhase();

                if (skipIcon != null)
                {
                    StartCoroutine(BlinkIcon());
                }
            }
        }
    }

    // Метод, який шукає найближчу контрольну точку і пересуває туди катсцену
    void SkipToNextPhase()
    {
        if (director == null || director.state != PlayState.Playing) return;

        // Поточний кадр катсцени 
        float currentTime = (float)director.time;

        // Пошук потрібного кадру
        foreach (int frame in frameCheckpoints)
        {
            float targetTime = frame / timelineFPS;

            if (targetTime > currentTime + 0.5f)
            {
                director.time = targetTime;
                director.Evaluate();
                break;
            }
        }
    }

    // Корутина для візуального відгуку підказки
    IEnumerator BlinkIcon()
    {
        skipIcon.alpha = dimAlpha;
        yield return new WaitForSeconds(0.15f);
        skipIcon.alpha = 1f;
    }
}