using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    [Header("Налаштування")]
    public AudioSource footstepSource;
    public float stepInterval = 0.6f;

    [Header("Гучність кроків")]
    public float maxVolume = 1f;

    private float stepTimer;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveZ != 0)
        {
            footstepSource.volume = maxVolume;

            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                footstepSource.pitch = Random.Range(0.9f, 1.1f);
                footstepSource.Play();
                stepTimer = stepInterval;
            }
        }
        else
        {
            if (footstepSource.isPlaying)
            {
                footstepSource.volume -= Time.deltaTime * 7f;

                if (footstepSource.volume <= 0f)
                {
                    footstepSource.Stop();
                }
            }

            stepTimer = 0f;
        }
    }
}