using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject TotalScore;
    public GameObject Score;
    public float displayTime;

    private int score = 0;

    private Text totalScoreText;

    void Start()
    {
        totalScoreText = TotalScore.GetComponent<Text>();
    }

    public void GainScore(int gainScore, Vector3 pos)
    {
        GameObject scoreDisplay = Instantiate(Score, pos, Quaternion.identity);
        scoreDisplay.transform.parent = gameObject.transform;

        score += gainScore;
        totalScoreText.text = "" + score;
    }
}
