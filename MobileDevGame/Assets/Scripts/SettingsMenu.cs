using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer m_audioMixer;

    public void SetVolume (float volume)
    {
        m_audioMixer.SetFloat("MasterVolume", volume);
    }
}
