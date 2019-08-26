using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLevel : MonoBehaviour
{
    private GameManager gameManager;
    private LevelManager levelManager;
    private PlatformManager platformManager;
   
    public int numberOfPlatform;
    public float timeSpawnPlatform;

    [System.Serializable]
    public class PlatformElement
    {
        public GameObject platform;
        [Range(0, 100)] public int spawnRate;

    };

    public PlatformElement[] Platforms;
}
