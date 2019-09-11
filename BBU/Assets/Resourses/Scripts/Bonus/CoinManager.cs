using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject Coin;
    public float minSpawnDuration;
    public float maxSpawnDuration;

    private int coinCollected;
    private float counter;
    private PlatformManager m_platformManager;
    private Vector3 worldWidth;
    private Vector3 worldHeight;

    // Spawn random 1~3 coins on screen
    // 1. Get number of coins to spawn
    // 2. Instantiate Coin prefab at position get by GetSpawnPos()
    // 3. Set parent for spawned coins
    private void SpawnCoin()
    {
        int noCoin = (int)Random.Range(1f, 4f);
        Debug.Log("Spawn " + noCoin);

        for(int i = 0; i < noCoin; i++)
        {
            GameObject spawnedCoin = Instantiate(Coin, GetSpawnPos(), Quaternion.identity);
            spawnedCoin.transform.parent = gameObject.transform;
        }
    }

    // Get next spawn time between minSpawnDuration and maxSpawnDuration
    private float GetSpawnTime()
    {
        return Random.Range(minSpawnDuration, maxSpawnDuration);
    }

    // Randomly generate a position con screen
    // 1. x is a random in the span of screen width
    // 2. y is a random in the span of screen height accecpt for where the platform stack (m_platformManager.GetStackHeight())
    private Vector2 GetSpawnPos()
    {
        float x = Random.Range(-worldWidth.x / 2, worldWidth.x / 2);
        float y = Random.Range((-worldHeight.y / 2) + m_platformManager.GetStackHeight(), worldHeight.y / 2);

        return new Vector2(x, y);
    }

    // function is called buy CoinBehavior whenever a coin get collected
    public void CollectCoin()
    {
        coinCollected += 1;
        Debug.Log(coinCollected);
    }

    private void Awake()
    {
        coinCollected = 0;
        worldWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        worldHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        counter = GetSpawnTime();
        m_platformManager = GameObject.Find("Platform").GetComponent<PlatformManager>();
    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;

        if (counter < 0)
        {
            SpawnCoin();
            counter = GetSpawnTime();
        }
    }
}
