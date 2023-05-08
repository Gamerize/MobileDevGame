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
        m_gameData.m_coins = ShopSystem.Coin;
        m_gameData.m_adTimeStamp = RewardedAdButton.PreviousTimestamp;
        m_gameData.m_blueUnlocked = ShopSystem.BlueUnlocked;
        m_gameData.m_greenUnlocked = ShopSystem.GreenUnlocked;
        m_gameData.m_p1RedEquip = EquipSystem.P1RedEquiped;
        m_gameData.m_p2RedEquip = EquipSystem.P2RedEquiped;
        m_gameData.m_p1BlueEquip = EquipSystem.P1BlueEquiped;
        m_gameData.m_p2BlueEquip = EquipSystem.P2BlueEquiped;
        m_gameData.m_p1GreenEquip = EquipSystem.P1GreenEquiped;
        m_gameData.m_p2GreenEquip = EquipSystem.P2GreenEquiped;
        m_gameData.m_RemovedAd = ShopSystem.RemovedAds;
        m_gameData.m_firstTimestamp = DailyReward.FirstTimestamp;

        string jsonString = JsonUtility.ToJson(m_gameData);

        File.WriteAllText(m_SaveFile, jsonString);
    }

    public void LoadData()
    {
        Sliders.musicVolume = m_gameData.m_musicVolumeValue;
        Sliders.SFXVolume = m_gameData.m_sfxVolumeValue;
        ShopSystem.Coin = m_gameData.m_coins;
        RewardedAdButton.PreviousTimestamp = m_gameData.m_adTimeStamp;
        ShopSystem.BlueUnlocked = m_gameData.m_blueUnlocked;
        ShopSystem.GreenUnlocked = m_gameData.m_greenUnlocked;
        EquipSystem.P1RedEquiped = m_gameData.m_p1RedEquip;
        EquipSystem.P2RedEquiped = m_gameData.m_p2RedEquip;
        EquipSystem.P1BlueEquiped = m_gameData.m_p1BlueEquip;
        EquipSystem.P2BlueEquiped = m_gameData.m_p2BlueEquip;
        EquipSystem.P1GreenEquiped = m_gameData.m_p1GreenEquip;
        EquipSystem.P2GreenEquiped = m_gameData.m_p2GreenEquip;
        ShopSystem.RemovedAds = m_gameData.m_RemovedAd;
        DailyReward.FirstTimestamp = m_gameData.m_firstTimestamp;
    }
}
