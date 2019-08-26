using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public InGameUIManager UIManager;
    public BallManager ballManager;
    public PlatformManager platformManager;
    public ScoreManager scoreManager;
    public BonusManager bonusManager;

    private bool isPlaying;
    public bool IsPlaying
    {
        get
        {
            return isPlaying;
        }
        set
        {
            isPlaying = value;
        }
    }

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isPlaying = true;
        ballManager.OnStartBall();
        levelManager.LoadLevel();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        isPlaying = false;
        SceneManager.LoadScene("EndGame");
    }
}
