using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameUIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditBoard;

    public void PressPlayButton()
    {
        SceneManager.LoadScene("InGame");
    }

    public void PressCreditButton()
    {
        creditBoard.SetActive(true);
    }

    public void PressBackButtonInCredit()
    {
        creditBoard.SetActive(false);
    }
}
