using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject m_PauseMenuUI;

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
        SceneManager.LoadScene("Main Menu");
    }
}
