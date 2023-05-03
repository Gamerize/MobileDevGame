using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    string m_SaveFile;

    GameData m_gameData = new GameData();

    private void Awake()
    {
        m_SaveFile = Application.persistentDataPath + "/gamedata.json";

        ReadFile();
    }

    public void ReadFile()
    {
        if (File.Exists(m_SaveFile))
        {
            string fileContents = File.ReadAllText(m_SaveFile);

            m_gameData = JsonUtility.FromJson<GameData>(fileContents);

            LoadData();
        }
        else
        {
            WriteFile();
        }
    }

    public void WriteFile()
    {
        m_gameData.m_musicVolumeValue = Sliders.musicVolume;
        m_gameData.m_sfxVolumeValue = Sliders.SFXVolume;

        string jsonString = JsonUtility.ToJson(m_gameData);

        File.WriteAllText(m_SaveFile, jsonString);
    }

    public void LoadData()
    {
        Sliders.musicVolume = m_gameData.m_musicVolumeValue;
        Sliders.SFXVolume = m_gameData.m_sfxVolumeValue;
    }
}
