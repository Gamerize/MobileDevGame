using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    public enum TurnState
    {
        START,
        DICE,
        P1ACTION,
        P2ACTION,
        P1WIN,
        P2WIN
    }

    public TurnState m_CurrentState;

    public DiceSystem m_DiceSystem;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentState = TurnState.START;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_CurrentState)
        {
            case TurnState.START:
                Debug.Log("Start phase");
                RoundStart();
                break;
            case TurnState.DICE:
                Debug.Log("Dice phase");
                CompareNum();
                break;
            case TurnState.P1ACTION:
                Debug.Log("P1 Action phase");
                break;
            case TurnState.P2ACTION:
                Debug.Log("P2 Action phase");
                break;
            case TurnState.P1WIN:
                Debug.Log("P1 Win");
                break;
            case TurnState.P2WIN:
                Debug.Log("P2 Win");
                break;
        }
    }

    void RoundStart()
    {
        m_DiceSystem.m_P1CanRoll = true;
        m_DiceSystem.m_P2CanRoll = true;
        m_CurrentState = TurnState.DICE;
    }

    void CompareNum()
    {
        if (m_DiceSystem.m_P1CanRoll == false && m_DiceSystem.m_P2CanRoll == false)
        {
            if (m_DiceSystem.m_P1DiceNum > m_DiceSystem.m_P2DiceNum)
            {
                m_CurrentState = TurnState.P1ACTION;
            }
            else if (m_DiceSystem.m_P1DiceNum < m_DiceSystem.m_P2DiceNum)
            {
                m_CurrentState = TurnState.P2ACTION;
            }
            else if (m_DiceSystem.m_P1DiceNum == m_DiceSystem.m_P2DiceNum)
            {
                m_CurrentState = TurnState.START;
            }
            Debug.Log("compared");
        }
    }
}
