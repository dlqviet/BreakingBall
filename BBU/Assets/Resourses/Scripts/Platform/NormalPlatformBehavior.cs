using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlatformBehavior : MonoBehaviour
{
    private ScoreManager scoreManager;
    private GameManager gameManager;

    public int HP;
    //private int currentHP;

    public GameObject[] perfectPoints;

    private Vector3 Pos;

    public void Die()
    {
        scoreManager.GainScore(1, Pos);
        gameObject.transform.parent.GetComponent<PlatformManager>().DestroyPlatform(gameObject);
    }

    void Start()
    {
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //currentHP = HP;

        //random perfect point
        int random = Random.Range(1, 5);
        switch (random)
        {
            case 1:
                perfectPoints[0].SetActive(true);
                break;
            case 2:
                perfectPoints[1].SetActive(true);
                break;
            case 3:
                perfectPoints[2].SetActive(true);
                break;
            case 4:
                perfectPoints[3].SetActive(true);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            Pos = gameObject.transform.position;
            currentHP -= collision.collider.gameObject.GetComponent<BallBehavior>().damage;


            if (currentHP == 0)
            {
                Die();
            }
        }

        if (collision.collider.name == "Roof")
        {
            gameManager.GameOver();
        }
    }

    private void FixedUpdate()
    {
        if (HP == 0)
        {
            scoreManager.GainScore(1, Pos);
            Destroy(gameObject);
        }
    }
}
