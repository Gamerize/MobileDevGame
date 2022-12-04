using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RollDice : MonoBehaviour
{
    public TextMeshProUGUI m_DiceText;
    public static int m_P1DiceNum = 1;
    public static int m_P2DiceNum = 1;

    public void P1DiceButton()
    {
        RandomP1DiceRoll(6);
    }

    public void P2DiceButton()
    {
        RandomP2DiceRoll(6);
    }

    void RandomP1DiceRoll(int MaxDiceRoll)
    {
        m_P1DiceNum = Random.Range(1, MaxDiceRoll+1);
        m_DiceText.text = m_P1DiceNum.ToString();
    }

    void RandomP2DiceRoll(int MaxDiceRoll)
    {
        m_P2DiceNum = Random.Range(1, MaxDiceRoll + 1);
        m_DiceText.text = m_P2DiceNum.ToString();
    }
}
