using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject m_mainMenu;
    [SerializeField]
    GameObject m_selectMenu;
    [SerializeField]
    GameObject m_settingsMenu;

    [SerializeField]
    AudioManager m_audioManager;

    private void Start()
    {
        m_settingsMenu.SetActive(false);
        m_mainMenu.SetActive(true);
        m_selectMenu.SetActive(false);
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
