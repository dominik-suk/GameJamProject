using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioMixer audioMixer;
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
