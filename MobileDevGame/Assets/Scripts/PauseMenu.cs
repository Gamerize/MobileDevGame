using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject m_PauseMenuUI;

    [SerializeField] AudioManager m_audioManager;
    [SerializeField] RewardedAdButton m_rewardedAdButton;
    [SerializeField] TurnSystem m_turnSystem;

    private void Start()
    {
        m_PauseMenuUI.SetActive(false);
    }

    public void Resume()
    {
        m_PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        m_PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Return()
    {
        m_PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "VS AI" && !ShopSystem.RemovedAds && m_turnSystem.m_CurrentState == TurnSystem.TurnState.GAMEOVER)
        {
            m_rewardedAdButton.ShowAdAfterMatch();
        }

        if (sceneName == "Gameplay" && !ShopSystem.RemovedAds && m_turnSystem.m_CurrentState == TurnSystem.TurnState.GAMEOVER)
        {
            m_rewardedAdButton.ShowAdAfterMatch();
        }

        m_audioManager.playAudio("Button");
        SceneManager.LoadScene("Main Menu");
    }
}
