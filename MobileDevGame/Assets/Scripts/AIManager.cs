using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AIManager : MonoBehaviour
{
    [Header("System")]
    [SerializeField] TurnSystem m_turnSystem;
    [SerializeField] ActionSystem m_actionSystem;
    [SerializeField] DiceSystem m_diceSystem;

    bool m_aiRolled;

    // Update is called once per frame
    void Update()
    {
        switch(m_turnSystem.m_CurrentState) 
        {
            case TurnSystem.TurnState.START: 
                m_aiRolled = false;
                break;
            case TurnSystem.TurnState.DICE:
                if(!m_aiRolled)
                {
                    m_diceSystem.P2DiceButton();
                    m_aiRolled = true;
                }              
                break;
            case TurnSystem.TurnState.P1ACTION:
                break;
            case TurnSystem.TurnState.P2ACTION: 
                if(m_actionSystem.m_P2FortCount > 2) 
                { 
                    //turrets
                    if(m_actionSystem.m_P2TurretCount == 0)
                    {
                        m_actionSystem.P2BuildTurret();
                    }
                    else if(m_actionSystem.m_P2TurretCount != 0)
                    {
                        if(m_actionSystem.m_P1BarrierCount != 0) 
                        {
                            m_actionSystem.P2AttackBarrier();
                        }
                        else
                        {
                            m_actionSystem.P2AttackFort();
                        }
                    }
                }
                else if (m_actionSystem.m_P2FortCount <= 2)
                {
                    //barriers
                    if (m_actionSystem.m_P2BarrierCount < 2)
                    {
                        m_actionSystem.P2BuildBarrier();
                    }
                    //turrets
                    else if (m_actionSystem.m_P2TurretCount == 0)
                    {
                        m_actionSystem.P2BuildTurret();
                    }
                    else if (m_actionSystem.m_P2TurretCount != 0)
                    {
                        if(m_actionSystem.m_P1TurretCount != 0)
                        {
                            m_actionSystem.P2AttackTurret();
                        }
                        else if (m_actionSystem.m_P1BarrierCount != 0)
                        {
                            m_actionSystem.P2AttackBarrier();
                        }
                        else
                        {
                            m_actionSystem.P2AttackFort();
                        }
                    }
                }
                break;
        }
    }
}
