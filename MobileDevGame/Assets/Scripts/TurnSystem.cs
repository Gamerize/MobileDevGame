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
        P2WIN,
        Wait
    }

    //States
    public TurnState m_CurrentState;

    //Scripts
    public DiceSystem m_DiceSystem;
    public ActionSystem m_ActionSystem;

    //Text
    public TextMeshProUGUI m_P1Text;
    public TextMeshProUGUI m_P2Text;

    //Time
    public float time;
    private float timeStore;

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
                CheckWin();
                break;
            case TurnState.P2ACTION:
                Debug.Log("P2 Action phase");
                CheckWin();
                break;
            case TurnState.P1WIN:
                Debug.Log("P1 Win");
                break;
            case TurnState.P2WIN:
                Debug.Log("P2 Win");
                break;
            case TurnState.Wait:
                Debug.Log("Wait");

                break;
        }
    }

    void RoundStart()
    {
        m_DiceSystem.m_P1CanRoll = true;
        m_DiceSystem.m_P2CanRoll = true;
        m_ActionSystem.m_HasActed = false;
        m_CurrentState = TurnState.DICE;
        m_P1Text.text = "Roll the Dice";
        m_P1Text.text = "Roll the Dice";
    }

    void CompareNum()
    {
        if (m_DiceSystem.m_P1CanRoll == false && m_DiceSystem.m_P2CanRoll == false)
        {
            if (m_DiceSystem.m_P1DiceNum > m_DiceSystem.m_P2DiceNum)
            {
                m_P1Text.text = "P1 Turn";
                m_P1Text.text = " ";
                m_CurrentState = TurnState.P1ACTION;
            }
            else if (m_DiceSystem.m_P1DiceNum < m_DiceSystem.m_P2DiceNum)
            {
                m_P1Text.text = " ";
                m_P2Text.text = "P2 Turn";
                m_CurrentState = TurnState.P2ACTION;
            }
            else if (m_DiceSystem.m_P1DiceNum == m_DiceSystem.m_P2DiceNum)
            {
                m_P1Text.text = "Reroll";
                m_P1Text.text = "Reroll";
                m_CurrentState = TurnState.START;
            }
            Debug.Log("compared");
        }
    }

    void Waiting(float WaitingTime, TurnState NextState)
    {
        
    }

    void CheckWin()
    {
        if(m_ActionSystem.m_HasActed == true)
        {
            m_CurrentState = TurnState.START;
        }
    }
}
