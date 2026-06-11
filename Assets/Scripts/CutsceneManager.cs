using UnityEngine;
using UnityEngine.Playables; // Бібліотека для роботи з Timeline та катсценами

// Головний клас для вимкнення управління персонажа під час катсцен
public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector director;
    public PlayerMovement playerMovement;
    public GameObject[] gameplayElements;
    public FootstepAudio footstepAudio;

    // Викликається, коли цей об'єкт вмикається
    private void OnEnable()
    {
        director.played += DisablePlayer;
        director.stopped += EnablePlayer;
    }

    // Викликається, коли цей об'єкт вимикається або знищується
    private void OnDisable()
    {
        director.played -= DisablePlayer;
        director.stopped -= EnablePlayer;
    }

    // Вимкнення персонажа якщо катсцена вже почалась
    private void Start()
    {
        if (director != null && director.state == PlayState.Playing)
        {
            DisablePlayer(director);
        }
    }

    // Метод для блокування управління та інтерфейсів
    private void DisablePlayer(PlayableDirector pd)
    {
        if (playerMovement != null) playerMovement.enabled = false;
        if (footstepAudio != null) footstepAudio.enabled = false;
        foreach (GameObject obj in gameplayElements)
        {
            if (obj != null) obj.SetActive(false);
        }
    }

    // Метод для відновлення управління та інтерфейсів
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