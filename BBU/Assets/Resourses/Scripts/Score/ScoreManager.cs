using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject TotalScore;
    public GameObject Score;
    public CoinManager CoinManager;
    public float displayTime;

    void Start()
    {
        
    }

    public void GainScore(int gainScore, Vector3 pos)
    {
        GameObject scoreDisplay = Instantiate(Score, pos, Quaternion.identity);
        scoreDisplay.transform.parent = gameObject.transform;

        CoinManager.CollectCoin(gainScore);
    }
}
