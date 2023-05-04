using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject m_mainMenu;
    [SerializeField] GameObject m_selectMenu;
    [SerializeField] GameObject m_settingsMenu;
    [SerializeField] GameObject m_CosmeticsMenu;
    [SerializeField] GameObject m_EquipMenu;
    [SerializeField] GameObject m_ShopMenu;

    [SerializeField] AudioManager m_audioManager;

    private void Start()
    {
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(true);
        m_selectMenu.SetActive(false);
        m_CosmeticsMenu.SetActive(false);
        m_EquipMenu.SetActive(false);
        m_ShopMenu.SetActive(false);
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

    public void Rematch()
    {
        m_audioManager.playAudio("Button");
        SceneManager.LoadScene("Gameplay");
    }

    public void Quit()
    {
        m_audioManager.playAudio("Button");
        Application.Quit();
    }
}
