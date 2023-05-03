using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Audio
{
    public string m_Name;
    public AudioClip Sound;

    public enum AudioTypes
    {
        Music,
        SFX
    }
    public AudioTypes audioType;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
