using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels;

    private PlatformManager platformManager;
    private int levelNo = 0;
    private int subLevelNo = 0;

    private int currentPlatformDestroyInlevel = 0;
    public int CurrentPlatformDestroyInlevel
    {
        get
        {
            return currentPlatformDestroyInlevel;
        }
        set
        {
            currentPlatformDestroyInlevel = value;
        }
    }

    private int currentPlatformInSublevel = 0;
    public int CurrentPlatformInSublevel
    {
        get
        {
            return currentPlatformInSublevel;
        }
        set
        {
            currentPlatformInSublevel = value;
        }
    }

    public void SpawnPlatformInSubLevel()
    {
        platformManager = GameObject.Find("Platform").GetComponent<PlatformManager>();
        if (currentPlatformInSublevel < levels[levelNo].LevelType.NormalLevelProperty.subLevels[subLevelNo].numberOfPlatform)
        {
            int randomRate = Random.Range(0, 101);
            int min = 0;
            int max = levels[levelNo].LevelType.NormalLevelProperty.subLevels[subLevelNo].Platforms[0].spawnRate;
            if (randomRate >= min && randomRate < max)
            {
                platformManager.SpawnPlatform(levels[levelNo].LevelType.NormalLevelProperty.subLevels[subLevelNo].Platforms[0].platform);
            }

            int i = 1;
            while (i < levels[levelNo].LevelType.NormalLevelProperty.subLevels[subLevelNo].Platforms.Length)
            {
                min += levels[levelNo].LevelType.NormalLevelProperty.subLevels[subLevelNo].Platforms[i-1].spawnRate;
                max += levels[levelNo].LevelType.NormalLevelProperty.subLevels[subLevelNo].Platforms[i].spawnRate;
                if (randomRate >= min && randomRate < max)
                {
                    platformManager.SpawnPlatform(levels[levelNo].LevelType.NormalLevelProperty.subLevels[subLevelNo].Platforms[i].platform);
                }
                i++;
            }
            currentPlatformInSublevel++;
        }
    }

    public void CheckSubLevelUp()
    { 
        if (currentPlatformInSublevel == levels[levelNo].LevelType.NormalLevelProperty.subLevels[subLevelNo].numberOfPlatform)
        {
            currentPlatformInSublevel = 0;
            subLevelNo++;
        }
    }

    public void CheckLevelUp()
    {
        if (levels[levelNo].LevelType.Type.ToString() == "NormalLevelProperty")
        {
            CheckSubLevelUp();
            if (currentPlatformDestroyInlevel == levels[levelNo].LevelType.NormalLevelProperty.numberOfPlatformDestroy)
            {
                currentPlatformDestroyInlevel = 0;
                levelNo++;
                subLevelNo = 0;
                LoadLevel();
            }
        }
        if (levels[levelNo].LevelType.Type.ToString() == "BossLevelProperty")
        {

        }
    }

    public void LoadLevel()
    {
        for(int i = 0; i < levels.Count; i++)
        {
            if (i == levelNo)
            {
                if (levels[i].LevelType.Type.ToString() == "NormalLevelProperty")
                {
                    LoadSubLevel();
                }
                if (levels[i].LevelType.Type.ToString() == "BossLevelProperty")
                {
                    
                }
            }
        }
    }

    public void LoadSubLevel()
    {
        for (int i = 0; i < levels[levelNo].LevelType.NormalLevelProperty.subLevels.Count; i++)
        {
            if (i == subLevelNo)
            {
                InvokeRepeating("SpawnPlatformInSubLevel", 0, levels[levelNo].LevelType.NormalLevelProperty.subLevels[i].timeSpawnPlatform);
            }
        }
    }

    private void Update()
    {
        CheckLevelUp();
    }
}
