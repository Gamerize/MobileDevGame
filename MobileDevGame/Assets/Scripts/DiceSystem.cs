using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceSystem : MonoBehaviour
{
    //Text
    public TextMeshProUGUI m_P1DiceNumText;
    public TextMeshProUGUI m_P2DiceNumText;

    //Num
    public int m_P1DiceNum;
    public int m_P2DiceNum;

    //Bool
    public bool m_P1CanRoll;
    public bool m_P2CanRoll;

    // Start is called before the first frame update
    void Start()
    {
        m_P1CanRoll = false;
        m_P2CanRoll = false;
    }

    public void P1DiceButton()
    {
        Debug.Log("Rolled P1");
        if (m_P1CanRoll == true)
        {
            P1RollDice(6);
            m_P1CanRoll = false;
        }
    }

    void P1RollDice(int maxInt)
    {
        int m_RandomInt = Random.Range(1, maxInt + 1);
        m_P1DiceNum = m_RandomInt;
        m_P1DiceNumText.text = m_RandomInt.ToString();
        Debug.Log("random num generated");
    }

    public void P2DiceButton()
    {
        Debug.Log("Rolled P2");
        if (m_P2CanRoll == true)
        {
            P2RollDice(6);
            m_P2CanRoll = false;
        }
    }

    void P2RollDice(int maxInt)
    {
        int m_RandomInt = Random.Range(1, maxInt + 1);
        m_P2DiceNum = m_RandomInt;
        m_P2DiceNumText.text = m_RandomInt.ToString();
        Debug.Log("random num generated");
    }
}
