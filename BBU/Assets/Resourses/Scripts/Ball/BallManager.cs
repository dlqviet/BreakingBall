using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [System.Serializable]
    public enum BallType
    {
        Cat,
        Chicken,
        Walrus,
        Penguin
    }
    public BallType m_Ball;

    public List<GameObject> balls;

    private GameObject startBall;
    private int randomRL;

    public int RandomRL
    {
        get
        {
            return randomRL;
        }
        set
        {
            randomRL = value;
        }
    }

    public void OnStartBall()
    {
        SpawnStartBall();
        startBall.GetComponent<Rigidbody2D>().velocity = new Vector2(5 * -randomRL, -1);
    }

    public void SpawnStartBall()
    {
        int random = Random.Range(0,2);
        if (random == 0)
        {
            randomRL = -1;
        }
        else
        {
            randomRL = 1;
        }
        startBall = Instantiate(balls[(int)m_Ball], GetStartBallPosition(), transform.rotation);
        startBall.transform.parent = gameObject.transform;
    }

    public void SpawnBonusBall(BallType ballType,Vector2 position)
    {
        GameObject newBall = Instantiate(balls[(int)ballType], position, transform.rotation);
        newBall.transform.parent = gameObject.transform;
    }

    public Vector2 GetStartBallPosition()
    {
        Vector2 pos;
        pos.x = 3 * randomRL;
        pos.y = 6;
        return pos;
    }
}
