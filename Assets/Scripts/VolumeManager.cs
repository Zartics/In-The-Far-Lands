using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [Header("Налаштування")]
    public AudioMixer myMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider voiceSlider;

    void Start()
    {
        float savedMusic = PlayerPrefs.GetFloat("MusicVol", 1f);
        float savedSFX = PlayerPrefs.GetFloat("SFXVol", 1f);
        float savedVoice = PlayerPrefs.GetFloat("VoiceVol", 1f);

        musicSlider.value = savedMusic;
        sfxSlider.value = savedSFX;
        voiceSlider.value = savedVoice;

        SetMusicVolume(savedMusic);
        SetSFXVolume(savedSFX);
        SetVoiceVolume(savedVoice);
    }

    public void SetMusicVolume(float sliderValue)
    {
        myMixer.SetFloat("MusicVol", Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f);

        PlayerPrefs.SetFloat("MusicVol", sliderValue);
    }

    public void SetSFXVolume(float sliderValue)
    {
        myMixer.SetFloat("SFXVol", Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f);
        PlayerPrefs.SetFloat("SFXVol", sliderValue);
    }

    public void SetVoiceVolume(float sliderValue)
    {
        myMixer.SetFloat("VoiceVol", Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20f);
        PlayerPrefs.SetFloat("VoiceVol", sliderValue);
    }
}