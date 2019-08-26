using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBehaviour : MonoBehaviour
{
    private BonusManager bonusManager;
    private BallManager ballManager;
    private float countdownTime;
    private void Start()
    {
        bonusManager = GetComponentInParent<BonusManager>();
        ballManager = GameObject.Find("Ball").GetComponent<BallManager>();
        countdownTime = bonusManager.CountdownTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            bonusManager.IncreaseBonusTime();
            bonusManager.NumberOfBall++;
            ballManager.SpawnBonusBall(0,transform.position);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        countdownTime -= Time.deltaTime;
        if (countdownTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
