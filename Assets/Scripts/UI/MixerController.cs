using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider, sFxSlider, ambienceSlider;
    private void OnEnable() {
        audioMixer.GetFloat("MusicVol", out float musicVol);
        musicSlider.value = Mathf.Pow(10, musicVol/20);
        audioMixer.GetFloat("SFXVol", out float sfxVol);
        sFxSlider.value = Mathf.Pow(10, sfxVol/20);
        audioMixer.GetFloat("AmbienceVol", out float ambienceVol);
        ambienceSlider.value = Mathf.Pow(10, ambienceVol/20);
    }
    public void UpdateMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVol", Mathf.Log10(value)*20);
    }
    public void UpdateSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVol", Mathf.Log10(value)*20);
    }
    public void UpdateAmbienceVolume(float value)
    {
        audioMixer.SetFloat("AmbienceVol", Mathf.Log10(value)*20);
    }
}
