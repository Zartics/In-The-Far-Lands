using UnityEngine;
using UnityEngine.Audio; // Бібліотека для роботи з Audio Mixer
using UnityEngine.UI; // Бібліотека для роботи з UI елементами

// Головний клас, який керує гучністю різних аудіоканалів та зберігає налаштування гравця
public class VolumeManager : MonoBehaviour
{
    [Header("Налаштування")]
    public AudioMixer myMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider voiceSlider;

    void Start()
    {
        // Береться значення з комп'ютера, якщо воно відсутнє, ставиться максимум
        float savedMusic = PlayerPrefs.GetFloat("MusicVol", 1f);
        float savedSFX = PlayerPrefs.GetFloat("SFXVol", 1f);
        float savedVoice = PlayerPrefs.GetFloat("VoiceVol", 1f);

        // Переписування повзунків на щойно поставлені позиції
        musicSlider.value = savedMusic;
        sfxSlider.value = savedSFX;
        voiceSlider.value = savedVoice;

        // Застосування гучності до мікшера
        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSFX);
        SetVoiceVolume(savedVoice);
    }

    // Метод для зміни гучності Музики (викликається автоматично при русі повзунка)
    public void SetMusicVolume(float sliderValue)
    {
        // Конвертація лінійного значення повзунка в логарифмічні Децибели і передання в Мікшер
        myMixer.SetFloat("MusicVol", Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f);

        // Збереження нового налаштування в пам'ять системи
        PlayerPrefs.SetFloat("MusicVol", sliderValue);
    }

    // Метод для зміни гучності Ефектів
    public void SetSFXVolume(float sliderValue)
    {
        myMixer.SetFloat("SFXVol", Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f);
        PlayerPrefs.SetFloat("SFXVol", sliderValue);
    }

    // Метод для зміни гучності Голосу
    public void SetVoiceVolume(float sliderValue)
    {
        myMixer.SetFloat("VoiceVol", Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f);
        PlayerPrefs.SetFloat("VoiceVol", sliderValue);
    }
}