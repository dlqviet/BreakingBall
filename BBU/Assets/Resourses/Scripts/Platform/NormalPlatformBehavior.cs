using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlatformBehavior : MonoBehaviour
{
    private ScoreManager scoreManager;
    private GameManager gameManager;

    public int HP;
    private int currentHP;

    private Vector3 Pos;

    void Start()
    {
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        currentHP = HP;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            Pos = gameObject.transform.position;
            currentHP--;
            if (currentHP == 0)
            {
                scoreManager.GainScore(1, Pos);
                Destroy(gameObject);
            }
        }

        if (collision.collider.name == "Roof")
        {
            gameManager.GameOver();
        }
    }
}
