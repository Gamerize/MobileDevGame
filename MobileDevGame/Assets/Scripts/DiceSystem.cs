using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceSystem : MonoBehaviour
{
    //Sprite
    [SerializeField] private Sprite[] m_diceSides;
    [SerializeField] private SpriteRenderer m_p1Renderer;
    [SerializeField] private SpriteRenderer m_p2Renderer;

    //Num
    public int m_P1DiceNum;
    public int m_P2DiceNum;

    //Bool
    public bool m_P1CanRoll;
    public bool m_P2CanRoll;
    private bool m_p1Ready;
    private bool m_p2Ready;

    //Scripts
    public TurnSystem m_TurnSystem;
    public AudioManager m_AudioManager;

    // Start is called before the first frame update
    void Start()
    {
        m_P1CanRoll = false;
        m_P2CanRoll = false;
        m_p1Ready = true;
        m_p2Ready = true;
}

    public void P1DiceButton()
    {
        Debug.Log("Rolled P1");
        if (m_P1CanRoll == true)
        {
            m_p1Ready = true;
            if (m_p1Ready)
            {
                m_AudioManager.playAudio("Roll");
                StartCoroutine("P1RollDice");
                m_p1Ready = false;
            }  
        }
    }

    public void P2DiceButton()
    {
        Debug.Log("Rolled P2");
        if (m_P2CanRoll == true)
        {
            m_p2Ready = true;
            if (m_p2Ready)
            {
                m_AudioManager.playAudio("Roll");
                StartCoroutine("P2RollDice");
                m_p2Ready = false;
            }
        }
    }

    private IEnumerator P1RollDice()
    {
        int m_RandomInt = 0;
        for (int i = 0; i < 20; i++)
        {
            m_RandomInt = Random.Range(0, 6);

            m_p1Renderer.sprite = m_diceSides[m_RandomInt];

            yield return new WaitForSeconds(0.05f);
        }
        m_P1DiceNum = m_RandomInt + 1;
        Debug.Log(m_P1DiceNum);
        m_TurnSystem.m_P1Text.text = "Rolled";
        m_P1CanRoll = false;
    }

    private IEnumerator P2RollDice()
    {
        int m_RandomInt = 0;
        for (int i = 0; i < 20; i++)
        {
            m_RandomInt = Random.Range(0, 6);

            m_p2Renderer.sprite = m_diceSides[m_RandomInt];

            yield return new WaitForSeconds(0.05f);
        }
        m_P2DiceNum = m_RandomInt + 1;
        Debug.Log(m_P2DiceNum);
        m_TurnSystem.m_P2Text.text = "Rolled";
        m_P2CanRoll = false;
    }
}
