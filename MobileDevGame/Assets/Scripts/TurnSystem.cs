using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { StartPhase, DicePhase, Player1Turn, Player2Turn, Player1Win, Player2Win}

public class TurnSystem : MonoBehaviour
{
    public BattleState state; 

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.StartPhase; 
        SetupMatch();
    }

    void SetupMatch()
    {
        DicePhase();
    }

    void DicePhase()
    {
        state = BattleState.DicePhase;
        int m_P1DiceRoll = RollDice.m_P1DiceNum;
        int m_P2DiceRoll = RollDice.m_P2DiceNum;
        do
        {
            if (m_P1DiceRoll > m_P2DiceRoll)
            {
                state = BattleState.Player1Turn;
                Debug.Log("Player 1 Turn");
            }
            else if (m_P1DiceRoll < m_P2DiceRoll)
            {
                state = BattleState.Player2Turn;
                Debug.Log("Player 2 Turn");
            }
        } while (m_P1DiceRoll == m_P2DiceRoll);
    }
}
