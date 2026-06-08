using System.Collections;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [Header("Посилання на монолог")]
    public AudioSource stanMonologue;

    [Header("Скільки секунд чекати перед словами?")]
    public float delayBeforeSpeaking = 3f;

    void OnEnable()
    {
        StartCoroutine(StartMonologueRoutine());
    }

    IEnumerator StartMonologueRoutine()
    {
        yield return new WaitForSeconds(delayBeforeSpeaking);
        stanMonologue.Play();
    }
}