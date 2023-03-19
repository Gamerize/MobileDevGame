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

    //Forts
    public int m_P1FortCount;
    public GameObject[] m_P1Forts;
    public int m_P2FortCount;
    public GameObject[] m_P2Forts;

    //Scripts
    public TurnSystem m_TurnSystem;
    public AudioManager m_AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        //Set Barriers
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

        //Set Turrets
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

        //Set Forts
        m_P1FortCount = m_P1Forts.Length;
        m_P2FortCount = m_P2Forts.Length;

        //Set Bool
        m_HasActed = true;
    }

    public void P1BuildBarrier()
    {
        if(m_P1BarrierCount < 3 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Draw");
            m_P1Barriers[m_P1BarrierCount].SetActive(true);
            m_P1BarrierCount++;
            m_HasActed = true;
            m_TurnSystem.m_P1Text.text = "Barrier Built";
            Debug.Log("P1 Build barrier");
        }
        else if (m_P1BarrierCount >= 3 && m_HasActed == false)
        {
            m_TurnSystem.m_P1Text.text = "Can't build more Barriers";
        }
        else
        {
            m_TurnSystem.m_P1Text.text = "Not Your Turn";
        }
    }

    public void P1BuildTurret()
    {
        if (m_P1TurretCount < 3 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Draw");
            m_P1Turrets[m_P1TurretCount].SetActive(true);
            m_P1TurretCount++;
            m_HasActed = true;
            m_TurnSystem.m_P1Text.text = "Turret Built";
            Debug.Log("P1 Build Turret");
        }
        else if (m_P1TurretCount >= 3 && m_HasActed == false)
        {
            m_TurnSystem.m_P1Text.text = "Can't build more Turrets";
        }
        else
        {
            m_TurnSystem.m_P1Text.text = "Not Your Turn";
        }
    }
    public void P2BuildBarrier()
    {
        if (m_P2BarrierCount < 3 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Draw");
            m_P2Barriers[m_P2BarrierCount].SetActive(true);
            m_P2BarrierCount++;
            m_HasActed = true;
            m_TurnSystem.m_P2Text.text = "Barrier Built";
            Debug.Log("P2 Build barrier");
        }
        else if (m_P2BarrierCount >= 3 && m_HasActed == false)
        {
            m_TurnSystem.m_P2Text.text = "Can't build more Barriers";
        }
        else
        {
            m_TurnSystem.m_P2Text.text = "Not Your Turn";
        }
    }

    public void P2BuildTurret()
    {
        if (m_P2TurretCount < 3 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Draw");
            m_P2Turrets[m_P2TurretCount].SetActive(true);
            m_P2TurretCount++;
            m_HasActed = true;
            m_TurnSystem.m_P2Text.text = "Turret Built";
            Debug.Log("P2 Build Turret");
        }
        else if (m_P2TurretCount >= 3 && m_HasActed == false)
        {
            m_TurnSystem.m_P2Text.text = "Can't build more Turrets";
        }
        else
        {
            m_TurnSystem.m_P2Text.text = "Not Your Turn";
        }
    }

    public void P1AttackTurret()
    { 
        if(m_P1TurretCount != 0 && m_P2TurretCount != 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Boom");
            m_P2Turrets[m_P2TurretCount-1].SetActive(false);
            m_P2TurretCount--;
            m_TurnSystem.m_P1Text.text = "P2 Turret Destroyed!";
            m_HasActed = true;
        }
        else if (m_P1TurretCount == 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P1Text.text = "No Turrets on field";
        }
        else if (m_P2TurretCount == 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P1Text.text = "No Turret to destroy";
        }
        else
        {
            m_TurnSystem.m_P1Text.text = "Not Your Turn";
        }
    }
    public void P2AttackTurret()
    {
        if (m_P2TurretCount != 0 && m_P1TurretCount != 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Boom");
            m_P1Turrets[m_P1TurretCount-1].SetActive(false);
            m_P1TurretCount--;
            m_TurnSystem.m_P2Text.text = "P1 Turret Destroyed!";
            m_HasActed = true;
        }
        else if (m_P2TurretCount == 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P2Text.text = "No Turrets on field";
        }
        else if (m_P1TurretCount == 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P1Text.text = "No Turret to destroy";
        }
        else
        {
            m_TurnSystem.m_P2Text.text = "Not Your Turn";
        }
    }

    public void P1AttackBarrier()
    {
        if (m_P1TurretCount != 0 && m_P2BarrierCount != 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Boom");
            m_P2Barriers[m_P2BarrierCount-1].SetActive(false);
            m_P2BarrierCount--;
            m_TurnSystem.m_P1Text.text = "P2 Barrier Destroyed!";
            m_HasActed = true;
        }
        else if (m_P1TurretCount == 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P1Text.text = "No Turrets on the field";
        }
        else if (m_P2BarrierCount == 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P1Text.text = "No Barrier to destroy";
        }
        else
        {
            m_TurnSystem.m_P1Text.text = "Not Your Turn";
        }
    }
    public void P2AttackBarrier()
    {
        if (m_P2TurretCount != 0 && m_P1BarrierCount != 0 && m_HasActed == false)
        {
            m_AudioManager.playAudio("Boom");
            m_P1Barriers[m_P1BarrierCount-1].SetActive(false);
            m_P1BarrierCount--;
            m_TurnSystem.m_P2Text.text = "P1 Barrier Destroyed!";
            m_HasActed = true;
        }
        else if (m_P2TurretCount == 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P2Text.text = "No Turrets on the field";
        }
        else if (m_P1BarrierCount == 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P2Text.text = "No Barrier to destroy";
        }
        else
        {
            m_TurnSystem.m_P2Text.text = "Not Your Turn";
        }
    }

    public void P1AttackFort()
    {
        if (m_P1TurretCount != 0 && m_P2FortCount != 0 && m_HasActed == false && m_P2BarrierCount == 0)
        {
            m_AudioManager.playAudio("Boom");
            m_P2Forts[m_P2FortCount - 1].SetActive(false);
            m_P2FortCount--;
            m_TurnSystem.m_P1Text.text = "P2 Fort Damaged!";
            m_HasActed = true;
        }
        else if (m_P1TurretCount == 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P1Text.text = "No Turrets on the field";
        }
        else if (m_P2BarrierCount != 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P1Text.text = "Their Fort is Protected";
        }
        else
        {
            m_TurnSystem.m_P1Text.text = "Not Your Turn";
        }
    }
    public void P2AttackFort()
    {
        if (m_P2TurretCount != 0 && m_P1FortCount != 0 && m_HasActed == false && m_P1BarrierCount == 0)
        {
            m_AudioManager.playAudio("Boom");
            m_P1Forts[m_P1FortCount - 1].SetActive(false);
            m_P1FortCount--;
            m_TurnSystem.m_P2Text.text = "P1 Fort Damaged!";
            m_HasActed = true;
        }
        else if (m_P2TurretCount == 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P2Text.text = "No Turrets on the field";
        }
        else if (m_P1BarrierCount != 0 && m_HasActed == false)
        {
            m_TurnSystem.m_P2Text.text = "Their Fort is Protected";
        }
        else
        {
            m_TurnSystem.m_P2Text.text = "Not Your Turn";
        }
    }
}
