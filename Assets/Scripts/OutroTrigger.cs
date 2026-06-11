using UnityEngine;
using UnityEngine.Playables; // Бібліотека для роботи з Timeline

// Головний клас, який запускає катсцену, коли гравець входить у певну зону
public class PlayCutsceneOnTrigger : MonoBehaviour
{
    public PlayableDirector timelineToPlay;
    private bool hasPlayed = false;

    // Функція, що спрацьовує, якщо саме гравець доторкнеться колайдера
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            timelineToPlay.Play();
        }
    }
}