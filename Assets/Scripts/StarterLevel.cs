using System.Collections; // Бібліотека для роботи з корутинами
using UnityEngine;

// Головний клас для запуску монологу на рівні
public class LevelStarter : MonoBehaviour
{
    [Header("Посилання на монолог")]
    public AudioSource stanMonologue;

    [Header("Скільки секунд чекати перед словами?")]
    public float delayBeforeSpeaking = 3f;

    // Вмикається щоразу, коли скрипт вмикається в грі
    void OnEnable()
    {
        StartCoroutine(StartMonologueRoutine());
    }

    // Корутина для створення паузи перед запуском
    IEnumerator StartMonologueRoutine()
    {
        yield return new WaitForSeconds(delayBeforeSpeaking);
        stanMonologue.Play();
    }
}