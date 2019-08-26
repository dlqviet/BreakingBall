using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUIManager : MonoBehaviour
{
    public void PressHomeButton()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void PressReplayButton()
    {
        SceneManager.LoadScene("InGame");
    }

}
