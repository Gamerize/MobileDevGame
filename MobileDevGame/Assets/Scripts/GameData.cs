using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float m_musicVolumeValue;
    public float m_sfxVolumeValue;

    public int m_coins;

    public double m_adTimeStamp;
    public double m_firstTimestamp;

    public bool m_blueUnlocked;
    public bool m_greenUnlocked;

    public bool m_p1RedEquip;
    public bool m_p2RedEquip;
    public bool m_p1BlueEquip;
    public bool m_p2BlueEquip;
    public bool m_p1GreenEquip;
    public bool m_p2GreenEquip;

    public bool m_RemovedAd;
}
