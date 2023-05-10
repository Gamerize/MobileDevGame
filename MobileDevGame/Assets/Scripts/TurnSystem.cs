using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TurnSystem : MonoBehaviour
{
    public enum TurnState
    {
        START,
        DICE,
        P1ACTION,
        P2ACTION,
        GAMEOVER,
        WAIT
    }

    //States
    public TurnState m_CurrentState;

    [Header("Scripts")]
    public DiceSystem m_DiceSystem;
    public ActionSystem m_ActionSystem;
    public AudioManager m_AudioManager;

    //Text
    public TextMeshProUGUI m_P1Text;
    public TextMeshProUGUI m_P2Text;
    public TextMeshProUGUI m_P1GameOverText;
    public TextMeshProUGUI m_P2GameOverText;

    //Time
    private float m_Time = 1f;
    private float m_TimeStore;

    //Bool
    bool m_P1Win;
    bool m_P2Win;

    //UI
    public GameObject m_GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentState = TurnState.START;
        m_TimeStore = m_Time;

        //Set UI
        m_GameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_CurrentState)
        {
            case TurnState.START:
                RoundStart();
                break;
            case TurnState.DICE:
                CompareNum();
                break;
            case TurnState.P1ACTION:
                CheckWin();
                break;
            case TurnState.P2ACTION:
                CheckWin();
                break;
            case TurnState.GAMEOVER:
                break;
            case TurnState.WAIT:
                break;
        }
    }

    void RoundStart()
    {
        m_DiceSystem.m_P1CanRoll = true;
        m_DiceSystem.m_P2CanRoll = true;
        m_DiceSystem.m_p1DiceButton.interactable = m_DiceSystem.m_p2DiceButton.interactable = true;
        m_CurrentState = TurnState.DICE;
        m_P1Text.text = "Roll the Dice";
        m_P2Text.text = "Roll the Dice";
    }

    void CompareNum()
    {
        if (m_DiceSystem.m_P1CanRoll == false && m_DiceSystem.m_P2CanRoll == false)
        {
            if (m_DiceSystem.m_P1DiceNum > m_DiceSystem.m_P2DiceNum)
            {
                m_AudioManager.playAudio("Turn");
                m_P1Text.text = "P1 Turn";
                m_P2Text.text = " ";
                m_ActionSystem.m_HasActed = false;
                m_CurrentState = TurnState.P1ACTION;
            }
            else if (m_DiceSystem.m_P1DiceNum < m_DiceSystem.m_P2DiceNum)
            {
                m_AudioManager.playAudio("Turn");
                m_P1Text.text = " ";
                m_P2Text.text = "P2 Turn";
                m_ActionSystem.m_HasActed = false;
                m_CurrentState = TurnState.P2ACTION;
            }
            else if (m_DiceSystem.m_P1DiceNum == m_DiceSystem.m_P2DiceNum)
            {
                m_AudioManager.playAudio("Reroll");
                m_P1Text.text = "Reroll";
                m_P1Text.text = "Reroll";
                m_CurrentState = TurnState.WAIT;
            }
            Debug.Log("compared");
        }
    }

    void Waiting(TurnState NextState)
    {
        if(m_Time > 0)
        {
            m_Time -= Time.deltaTime;
        }
        else
        {
            m_CurrentState = NextState;
            m_Time = m_TimeStore;
        }
    }

    void CheckWin()
    {
        if(m_ActionSystem.m_HasActed && m_ActionSystem.m_P2FortCount <= 0)
        {
            m_GameOverUI.SetActive(true);
            m_AudioManager.playAudio("Cheer");
            m_P1Text.text = m_P2Text.text = " ";
            m_P1GameOverText.text = "You Win";
            m_P2GameOverText.text = "You Lose";
            m_CurrentState = TurnState.GAMEOVER;
        }
        else if (m_ActionSystem.m_HasActed && m_ActionSystem.m_P1FortCount <= 0)
        {
            m_GameOverUI.SetActive(true);
            m_AudioManager.playAudio("Cheer");
            m_P1Text.text = m_P2Text.text = " ";
            m_P1GameOverText.text = "You Lose";
            m_P2GameOverText.text = "You Win";           
            m_CurrentState = TurnState.GAMEOVER;
        }
        else if (m_ActionSystem.m_HasActed)
        {
            m_CurrentState = TurnState.WAIT;
        }
    }
}
