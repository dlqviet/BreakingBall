using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{

    public GameObject m_inGameUI;
    public GameObject m_screenInGame;
    public GameObject m_pauseMenu;
    public GameObject m_inGame;

    public void PressPauseButton()
    {
        m_screenInGame.SetActive(false);
        m_pauseMenu.SetActive(true);
    }

    public void PressResumeButton()
    {
        m_pauseMenu.SetActive(false);
        m_screenInGame.SetActive(true);
    }

    public void PressReplayButtonInPauseMenu()
    {
        SceneManager.LoadScene("InGame");
    }

    public void PressHomeButtonInPauseMenu()
    {
        SceneManager.LoadScene("StartGame");
    }
}
