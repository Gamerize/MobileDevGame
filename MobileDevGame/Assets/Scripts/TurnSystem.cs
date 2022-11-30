using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, DiceRoll, Player1Turn, Player2Turn, Player1Win, Player2Win}

public class TurnSystem : MonoBehaviour
{
    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start; 
        
    }

    void RollDice()
    {
        state = BattleState.DiceRoll;

    }
}
