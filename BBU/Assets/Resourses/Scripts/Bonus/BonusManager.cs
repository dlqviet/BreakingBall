using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public GameObject bonus;
    public int NumberOfBall;
    public float bonusStartTime;
    public float bonusNextTime;

    private float bonusTime;
    private float countdownTime;
    public float CountdownTime
    {
        get
        {
            return countdownTime;
        }
        set
        {
            countdownTime = value;
        }
    }
    private void Start()
    {
        bonusTime = bonusStartTime;
        countdownTime = bonusTime;
    }

    public void IncreaseBonusTime()
    {
        bonusTime += bonusNextTime;
        countdownTime = bonusTime;
    }
    public void DecreaseBonusTime()
    {
        bonusTime -= bonusNextTime;
        countdownTime = bonusTime;
    }
    public void ResetBonusTime()
    {
        bonusTime = bonusStartTime;
        countdownTime = bonusTime;
    }
    public void SpawnBonus()
    {
        Debug.Log(111111111111111);
        IncreaseBonusTime();
        GameObject newBonus = Instantiate(bonus, GetBonusPosition(), transform.rotation);
        newBonus.transform.parent = gameObject.transform;
    }
    public Vector2 GetBonusPosition()
    {
        int random;
        if (Random.Range(0, 2) == 1)
        {
            random = 1;
        }
        else
        {
            random = -1;
        }
        float randX = (float)(random * (1.75 + 1.45 * Random.Range(0f,1f)));
        float randY = Random.Range(0f, 1f) * 6;
        Vector2 tmp = new Vector2(randX, randY);
        return tmp;
    }


    private void FixedUpdate()
    {
        countdownTime -= Time.deltaTime;
        if (countdownTime == 0f)
        {
            SpawnBonus();
        }
    }
}
