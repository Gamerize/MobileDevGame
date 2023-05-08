using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using static TurnSystem;
using Unity.VisualScripting;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    public static int Coin { get; set; }

    [Header("Text")]
    [SerializeField] TextMeshProUGUI m_currentCoinText1;
    [SerializeField] TextMeshProUGUI m_currentCoinText2;
    [SerializeField] TextMeshProUGUI m_BuyMessage;

    public static bool BlueUnlocked;
    public static bool GreenUnlocked;
    public static bool RemovedAds;

    [Header("Systems")]
    [SerializeField] AudioManager m_audioManager;

    [Header("Buttons")]
    [SerializeField] Button m_blueButton;
    [SerializeField] Button m_greenButton;
    [SerializeField] Button m_RemoveAdsButton;

    // Update is called once per frame
    void Update()
    {
        m_currentCoinText1.text = m_currentCoinText2.text = Coin.ToString();
        if(BlueUnlocked)
        {
            m_blueButton.interactable = false;
        }
        if(GreenUnlocked) 
        {
            m_greenButton.interactable = false;
        }
        if(RemovedAds) 
        {
            m_RemoveAdsButton.interactable = false;
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

    public void BuyBlueCosmetic()
    {
        if (checkCurrency(100))
        {
            Coin -= 100;
            m_BuyMessage.text = "Bought Blue Crossbow";
            m_audioManager.playAudio("Cashier");
            BlueUnlocked = true;
        }
        else
        {
            m_BuyMessage.text = "Not Enough Coins";
            m_audioManager.playAudio("Error");
        }
    }

    public void BuyGreenCosmetic()
    {
        if (checkCurrency(100))
        {
            Coin -= 100;
            m_BuyMessage.text = "Bought Green Catapult";
            m_audioManager.playAudio("Cashier");
            GreenUnlocked = true;
        }
        else
        {
            m_BuyMessage.text = "Not Enough Coins";
            m_audioManager.playAudio("Error");
        }
    }

    public void NoAds(UnityEngine.Purchasing.Product product)
    {
        CustomEvent.Trigger(gameObject, "No Ads", product.definition.payout.quantity);
        RemovedAds = true;
    }
}
