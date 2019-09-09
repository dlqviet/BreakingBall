using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject Coin;
    public float minSpawnDuration;
    public float maxSpawnDuration;

    private float m_counter;
    private float screenWidth;
    private float screenHeight;
    private PlatformManager m_platformManager;

    private void SpawnCoin()
    {
        int noCoin = (int)Random.Range(1f, 4f);

        for(int i = 0; i < noCoin; i++)
        {
            GameObject spawnedCoin = Instantiate(Coin, GetSpawnPos(), Quaternion.identity); 
        }
    }

    private float GetSpawnTime()
    {
        return Random.Range(minSpawnDuration, maxSpawnDuration);
    }

    private Vector2 GetSpawnPos()
    {
        float x = Random.Range(-screenWidth / 2, screenWidth / 2);
        float y = Random.Range((-screenHeight / 2) + m_platformManager.GetStackHeight(), screenHeight / 2);

        return new Vector2(x, y);
    }

    private void Awake()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_counter = GetSpawnTime();
        m_platformManager = GameObject.Find("Platform").GetComponent<PlatformManager>();
    }

    // Update is called once per frame
    void Update()
    {
        m_counter -= Time.deltaTime;

        if (m_counter < 0)
        {
            SpawnCoin();
            m_counter = GetSpawnTime();
        }
    }
}
