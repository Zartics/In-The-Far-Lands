using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector director;
    public PlayerMovement playerMovement;
    public GameObject[] gameplayElements;
    public FootstepAudio footstepAudio;

    private void OnEnable()
    {
        director.played += DisablePlayer;
        director.stopped += EnablePlayer;
    }

    private void OnDisable()
    {
        director.played -= DisablePlayer;
        director.stopped -= EnablePlayer;
    }

    private void Start()
    {
        if (playerMovement == null)
        {
            Debug.LogError("Поле Player Movement порожнє!");
        }

        if (director != null && director.state == PlayState.Playing)
        {
            DisablePlayer(director);
        }
    }

    private void DisablePlayer(PlayableDirector pd)
    {
        if (playerMovement != null) playerMovement.enabled = false;
        if (footstepAudio != null) footstepAudio.enabled = false;
        foreach (GameObject obj in gameplayElements)
        {
            if (obj != null) obj.SetActive(false);
        }
    }

    private void EnablePlayer(PlayableDirector pd)
    {
        if (playerMovement != null) playerMovement.enabled = true;
        if (footstepAudio != null) footstepAudio.enabled = true;
        foreach (GameObject obj in gameplayElements)
        {
            if (obj != null) obj.SetActive(true);
        }
    }
}