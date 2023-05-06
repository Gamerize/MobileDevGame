using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static TurnSystem;

public class ShopSystem : MonoBehaviour
{
    public static int Coin { get; set; }

    [Header("Text")]
    [SerializeField] TextMeshProUGUI m_currentCointext;
    [SerializeField] TextMeshProUGUI m_BuyMessage;

    public static bool BlueUnlocked;
    public static bool GreenUnlocked;

    [Header("Systems")]
    [SerializeField] AudioManager m_audioManager;

    [Header("Buttons")]
    [SerializeField] Button m_blueButton;
    [SerializeField] Button m_greenButton;

    private float m_time = 1f;
    private float m_timeStore;

    // Update is called once per frame
    void Update()
    {
        m_currentCointext.text = Coin.ToString();
        if(BlueUnlocked)
        {
            m_blueButton.interactable = false;
        }
        if(GreenUnlocked) 
        {
            m_greenButton.interactable = false;
        }
    }

    public bool checkCurrency(int price)
    {
        if(Coin >= price) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Waiting()
    {
        if (m_time > 0)
        {
            m_time -= Time.deltaTime;
        }
        else
        {
            m_BuyMessage.text = " ";
            m_time = m_timeStore;
        }
    }

    public void BuyBlueCosmetic()
    {
        if (checkCurrency(50))
        {
            Coin -= 50;
            m_BuyMessage.text = "Bought Blue Crossbow";
            m_audioManager.playAudio("Cashier");
            BlueUnlocked = true;
        }
        else
        {
            m_BuyMessage.text = "Not Enough Coins";
            m_audioManager.playAudio("Error");
            Waiting();
        }
    }

    public void BuyGreenCosmetic()
    {
        if (checkCurrency(50))
        {
            Coin -= 50;
            m_BuyMessage.text = "Bought Green Catapult";
            m_audioManager.playAudio("Cashier");
            GreenUnlocked = true;
        }
        else
        {
            m_BuyMessage.text = "Not Enough Coins";
            m_audioManager.playAudio("Error");
            Waiting();
        }
    }
}
