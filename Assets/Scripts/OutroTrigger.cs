using UnityEngine;
using UnityEngine.Playables;

public class PlayCutsceneOnTrigger : MonoBehaviour
{
    public PlayableDirector timelineToPlay;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            timelineToPlay.Play();
        }
    }
}