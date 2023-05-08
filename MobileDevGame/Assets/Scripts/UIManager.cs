using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject m_mainMenu;
    [SerializeField] GameObject m_selectMenu;
    [SerializeField] GameObject m_settingsMenu;
    [SerializeField] GameObject m_CosmeticsMenu;
    [SerializeField] GameObject m_EquipMenu;
    [SerializeField] GameObject m_ShopMenu;
    [SerializeField] GameObject m_noAdsMenu;
    [SerializeField] GameObject m_dailyRewardMenu;
    [SerializeField] GameObject m_intructionsMenu;
    [SerializeField] GameObject m_FacebookMenu;

    [Header("Instruction Pages")]
    [SerializeField] GameObject m_Page1;
    [SerializeField] GameObject m_Page2;
    [SerializeField] GameObject m_Page3;
    [SerializeField] GameObject m_Page4;
    [SerializeField] GameObject m_Page5;

    [Header("System")]
    [SerializeField] AudioManager m_audioManager;
    [SerializeField] RewardedAdButton m_rewardedAdButton;

    private void Start()
    {
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(true);
        m_selectMenu.SetActive(false);
        m_CosmeticsMenu.SetActive(false);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(false);
        m_noAdsMenu.SetActive(false);
        m_dailyRewardMenu.SetActive(false);
        m_intructionsMenu.SetActive(false);
        m_FacebookMenu.SetActive(false);
    }

    public void OpenSettings()
    {
        m_audioManager.playAudio("Settings");
        m_settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        m_audioManager.playAudio("Settings");
        m_settingsMenu.SetActive(false);
    }

    public void OpenInstructions()
    {
        m_audioManager.playAudio("Button");
        m_intructionsMenu.SetActive(true);
        m_Page1.SetActive(true);
        m_Page2.SetActive(false);
        m_Page3.SetActive(false);
        m_Page4.SetActive(false);
        m_Page5.SetActive(false);
    }
    public void CloseInstructions()
    {
        m_audioManager.playAudio("Button");
        m_intructionsMenu.SetActive(false);
        m_Page1.SetActive(false);
        m_Page2.SetActive(false);
        m_Page3.SetActive(false);
        m_Page4.SetActive(false);
        m_Page5.SetActive(false);
    }
    public void ToPage2()
    {
        m_audioManager.playAudio("Button");
        m_intructionsMenu.SetActive(true);
        m_Page1.SetActive(false);
        m_Page2.SetActive(true);
        m_Page3.SetActive(false);
        m_Page4.SetActive(false);
        m_Page5.SetActive(false);
    }
    public void ToPage3()
    {
        m_audioManager.playAudio("Button");
        m_intructionsMenu.SetActive(true);
        m_Page1.SetActive(false);
        m_Page2.SetActive(false);
        m_Page3.SetActive(true);
        m_Page4.SetActive(false);
        m_Page5.SetActive(false);
    }
    public void ToPage4()
    {
        m_audioManager.playAudio("Button");
        m_intructionsMenu.SetActive(true);
        m_Page1.SetActive(false);
        m_Page2.SetActive(false);
        m_Page3.SetActive(false);
        m_Page4.SetActive(true);
        m_Page5.SetActive(false);
    }
    public void ToPage5()
    {
        m_audioManager.playAudio("Button");
        m_intructionsMenu.SetActive(true);
        m_Page1.SetActive(false);
        m_Page2.SetActive(false);
        m_Page3.SetActive(false);
        m_Page4.SetActive(false);
        m_Page5.SetActive(true);
    }

    public void OpenCosmetics()
    {
        m_audioManager.playAudio("Button"); 
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(false);
        m_selectMenu.SetActive(false);
        m_CosmeticsMenu.SetActive(true);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(true);
    }

    public void CloseCosmetics()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(true);
        m_selectMenu.SetActive(false);
        m_CosmeticsMenu.SetActive(false);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(false);
    }

    public void OpenMode()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(false);
        m_selectMenu.SetActive(true);
        m_CosmeticsMenu.SetActive(false);
    }
    public void CloseMode()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(true);
        m_selectMenu.SetActive(false);
        m_CosmeticsMenu.SetActive(false);
    }

    public void ShopOn()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(false);
        m_selectMenu.SetActive(false);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(true);
    }

    public void EquipOn()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(false);
        m_selectMenu.SetActive(false);
        m_EquipMenu.SetActive(true);
        m_ShopMenu.SetActive(false);
    }

    public void OpenAdsMenu()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(false);
        m_selectMenu.SetActive(false);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(false);
        m_noAdsMenu.SetActive(true);
    }
    public void CloseAdsMenu()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(true);
        m_selectMenu.SetActive(false);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(false);
        m_noAdsMenu.SetActive(false);
    }

    public void OpenRewardMenu()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_selectMenu.SetActive(false);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(false);
        m_noAdsMenu.SetActive(false);
        m_dailyRewardMenu.SetActive(true);
    }
    public void CloseRewardMenu()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_selectMenu.SetActive(false);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(false);
        m_noAdsMenu.SetActive(false);
        m_dailyRewardMenu.SetActive(false);
    }
    public void OpenFacebookMenu()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_selectMenu.SetActive(false);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(false);
        m_noAdsMenu.SetActive(false);
        m_dailyRewardMenu.SetActive(false);
        m_FacebookMenu.SetActive(true);
    }
    public void CloseFacebookMenu()
    {
        m_audioManager.playAudio("Button");
        m_settingsMenu.SetActive(false);
        m_selectMenu.SetActive(false);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(false);
        m_noAdsMenu.SetActive(false);
        m_dailyRewardMenu.SetActive(false);
        m_FacebookMenu.SetActive(false);
    }


    public void AIMatch()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "VS AI" && !ShopSystem.RemovedAds)
        {
            m_rewardedAdButton.ShowAdAfterMatch();
        }
        m_audioManager.playAudio("Button");
        SceneManager.LoadScene("VS AI");
    }

    public void Multiplayer()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Gameplay" && !ShopSystem.RemovedAds)
        {
            m_rewardedAdButton.ShowAdAfterMatch();
        }
        m_audioManager.playAudio("Button");
        SceneManager.LoadScene("Gameplay");
    }

    public void Quit()
    {
        m_audioManager.playAudio("Button");
        Application.Quit();
    }
}
