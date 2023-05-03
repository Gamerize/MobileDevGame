using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool m_paused = false;

    public GameObject m_PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(m_paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume()
    {
        m_PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        m_paused = false;
    }

    void Pause()
    {
        m_PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        m_paused = true;
    }
}
