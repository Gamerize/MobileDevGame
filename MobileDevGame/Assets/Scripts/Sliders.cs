using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Sliders : MonoBehaviour
{
    //private static float m_musicBarValue = 0.5f;
    //private static float m_soundBarValue = 0.5f;
    [SerializeField] private Slider m_musicBar;
    [SerializeField] private Slider m_soundBar;
    [SerializeField] TextMeshProUGUI MusicText;
    [SerializeField] TextMeshProUGUI SFXText;

    public static float musicVolume { get; set; }
    public static float SFXVolume { get;  set; }


    private void Start()
    {
        m_musicBar.value = musicVolume;
        m_soundBar.value = SFXVolume;
    }

    public void OnMusicSliderValueChange()
    {
        musicVolume = m_musicBar.value;
        MusicText.text = ((int)(musicVolume * 100)).ToString();
        AudioManager.instance.UpdateMixerVolume();
    }

    public void OnSFXSliderValueChange()
    {
        SFXVolume = m_soundBar.value;
        SFXText.text = ((int)(SFXVolume * 100)).ToString();
        AudioManager.instance.UpdateMixerVolume();
    }
}
