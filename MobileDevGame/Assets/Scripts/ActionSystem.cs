using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    //bool
    public bool m_HasActed;

    //Barriers
    public int m_P1BarrierCount;
    public GameObject[] m_P1Barriers;
    public int m_P2BarrierCount;
    public GameObject[] m_P2Barriers;

    //Turrets
    public int m_P1TurretCount;
    public GameObject[] m_P1Turrets;
    public int m_P2TurretCount;
    public GameObject[] m_P2Turrets;

    // Start is called before the first frame update
    void Start()
    {
        m_P1BarrierCount = 0;
        for (int i = 0; i < m_P1Barriers.Length; i++)
        {
            m_P1Barriers[i].SetActive(false);
        }
        m_P2BarrierCount = 0;
        for (int i = 0; i < m_P2Barriers.Length; i++)
        {
            m_P2Barriers[i].SetActive(false);
        }
        m_P1TurretCount = 0;
        for (int i = 0; i < m_P1Turrets.Length; i++)
        {
            m_P1Turrets[i].SetActive(false);
        }
        m_P2TurretCount = 0;
        for (int i = 0; i < m_P2Turrets.Length; i++)
        {
            m_P2Turrets[i].SetActive(false);
        }
        m_HasActed = false;
    }

    public void P1BuildBarrier()
    {
        if(m_P1BarrierCount < 3 && m_HasActed == false)
        {
            m_P1Barriers[m_P1BarrierCount].SetActive(true);
            m_P1BarrierCount++;
            m_HasActed = true;
            Debug.Log("P1 Build barrier");
        }
    }

    public void P1BuildTurret()
    {
        if (m_P1TurretCount < 3 && m_HasActed == false)
        {
            m_P1Turrets[m_P1TurretCount].SetActive(true);
            m_P1TurretCount++;
            m_HasActed = true;
            Debug.Log("P1 Build Turret");
        }
    }
    public void P2BuildBarrier()
    {
        if (m_P2BarrierCount < 3 && m_HasActed == false)
        {
            m_P2Barriers[m_P2BarrierCount].SetActive(true);
            m_P2BarrierCount++;
            m_HasActed = true;
            Debug.Log("P2 Build barrier");
        }
    }

    public void P2BuildTurret()
    {
        if (m_P2TurretCount < 3 && m_HasActed == false)
        {
            m_P2Turrets[m_P2TurretCount].SetActive(true);
            m_P2TurretCount++;
            m_HasActed = true;
            Debug.Log("P2 Build Turret");
        }
    }
}
