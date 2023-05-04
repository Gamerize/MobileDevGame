using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField] SaveSystem m_saveSystem;

    // Update is called once per frame
    void Update()
    {
        m_currentCointext.text = Coin.ToString();
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

    public void BuyBlueCosmetic()
    {
        if (checkCurrency(50))
        {
            Coin -= 50;
            m_BuyMessage.text = " ";
            m_audioManager.playAudio("Cashier");
            BlueUnlocked = true;
            m_saveSystem.WriteFile();
        }
        else
        {
            m_BuyMessage.text = "Not Enough Coins";
            m_audioManager.playAudio("Error");
        }
    }

    public void BuyGreenCosmetic()
    {
        if (checkCurrency(50))
        {
            Coin -= 50;
            m_BuyMessage.text = " ";
            m_audioManager.playAudio("Cashier");
            GreenUnlocked = true;
            m_saveSystem.WriteFile();
        }
        else
        {
            m_BuyMessage.text = "Not Enough Coins";
            m_audioManager.playAudio("Error");
        }
    }
}
