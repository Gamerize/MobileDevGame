using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipSystem : MonoBehaviour
{
    public static bool P1RedEquiped;
    public static bool P2RedEquiped;
    public static bool P1BlueEquiped;
    public static bool P2BlueEquiped;
    public static bool P1GreenEquiped;
    public static bool P2GreenEquiped;

    [Header("Buttons")]
    [SerializeField] Button m_P1RedButton;
    [SerializeField] Button m_P2RedButton;
    [SerializeField] Button m_P1BlueButton;
    [SerializeField] Button m_P2BlueButton;
    [SerializeField] Button m_P1GreenButton;
    [SerializeField] Button m_P2GreenButton;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI m_P1RedButtonText;
    [SerializeField] TextMeshProUGUI m_P2RedButtonText;
    [SerializeField] TextMeshProUGUI m_P1BlueButtonText;
    [SerializeField] TextMeshProUGUI m_P2BlueButtonText;
    [SerializeField] TextMeshProUGUI m_P1GreenButtonText;
    [SerializeField] TextMeshProUGUI m_P2GreenButtonText;


    // Update is called once per frame
    void Update()
    {
        if (ShopSystem.BlueUnlocked && ShopSystem.GreenUnlocked)
        {
            if (P1RedEquiped)
            {
                m_P1RedButton.interactable = false;
            }
            else
            {
                m_P1RedButton.interactable = true;
            }

            if (P2RedEquiped)
            {
                m_P2RedButton.interactable = false;
            }
            else
            {
                m_P2RedButton.interactable = true;
            }
        }
        else 
        {
            P1RedEquiped = P2RedEquiped = true;
            m_P1RedButtonText.text = "P1 Equipped";
            m_P2RedButtonText.text = "P2 Equipped";
            m_P1RedButton.interactable = m_P2RedButton.interactable = false;
        }
        
        if(ShopSystem.BlueUnlocked)
        {
            if (P1BlueEquiped)
            {
                m_P1BlueButton.interactable = false;
            }
            else
            {
                m_P1BlueButton.interactable = true;
            }

            if (P2BlueEquiped)
            {
                m_P2BlueButton.interactable = false;
            }
            else
            {
                m_P2BlueButton.interactable = true;
            }
        }
        else
        {
            m_P1BlueButton.interactable = m_P2BlueButton.interactable = false;
        }


        if(ShopSystem.GreenUnlocked) 
        {
            if (P1GreenEquiped)
            {
                m_P1GreenButton.interactable = false;
            }
            else
            {
                m_P1GreenButton.interactable = true;
            }

            if (P2GreenEquiped)
            {
                m_P2GreenButton.interactable = false;
            }
            else
            {
                m_P2GreenButton.interactable = true;
            }
        }
        else
        {
            m_P1GreenButton.interactable = m_P2GreenButton.interactable = false;
        }

    }

    public void P1RedButton()
    {
        if(!P1RedEquiped)
        {
            P1RedEquiped = true;
            P1BlueEquiped = false;
            P1GreenEquiped = false;

            m_P1RedButtonText.text = "P1 Equipped";
            m_P1BlueButtonText.text = "P1 Equip";
            m_P1GreenButtonText.text = "P1 Equip";
        }
    }
    public void P2RedButton()
    {
        if(!P2RedEquiped)
        {
            P2RedEquiped = true;
            P2BlueEquiped = false;
            P2GreenEquiped = false;

            m_P2RedButtonText.text = "P2 Equipped";
            m_P2BlueButtonText.text = "P2 Equip";
            m_P2GreenButtonText.text = "P2 Equip";
        }
    }
    public void P1BlueButton()
    {
        if (!P1BlueEquiped)
        {
            P1RedEquiped = false;
            P1BlueEquiped = true;
            P1GreenEquiped = false;

            m_P1RedButtonText.text = "P1 Equip";
            m_P1BlueButtonText.text = "P1 Equipped";
            m_P1GreenButtonText.text = "P1 Equip";
        }
    }
    public void P2BlueButton()
    {
        if (!P2BlueEquiped)
        {
            P2RedEquiped = false;
            P2BlueEquiped = true;
            P2GreenEquiped = false;

            m_P2RedButtonText.text = "P2 Equip";
            m_P2BlueButtonText.text = "P2 Equipped";
            m_P2GreenButtonText.text = "P2 Equip";
        }
    }
    public void P1GreenButton()
    {
        if (!P1GreenEquiped)
        {
            P1RedEquiped = false;
            P1BlueEquiped = false;
            P1GreenEquiped = true;

            m_P1RedButtonText.text = "P1 Equip";
            m_P1BlueButtonText.text = "P1 Equip";
            m_P1GreenButtonText.text = "P1 Equipped";
        }
    }
    public void P2GreenButton()
    {
        if (!P2GreenEquiped)
        {
            P2RedEquiped = false;
            P2BlueEquiped = false;
            P2GreenEquiped = true;

            m_P2RedButtonText.text = "P2 Equip";
            m_P2BlueButtonText.text = "P2 Equip";
            m_P2GreenButtonText.text = "P2 Equipped";
        }
    }
}

