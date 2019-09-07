using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private List<GameObject> platformList = new List<GameObject>();

    public void SpawnPlatform(GameObject platformType)
    {
        GameObject newPlatform = Instantiate(platformType, GetPlatformPosition(), transform.rotation);
        newPlatform.transform.parent = gameObject.transform;
        platformList.Add(newPlatform);
    }

    public void DestroyPlatform(GameObject platform)
    {
        if (platformList.Remove(platform))
        {
            Destroy(platform);
        }
    }

    public Vector2 GetPlatformPosition()
    {
        Vector2 pos;
        pos.x = 0;
        pos.y = 1.2f * platformList.Count - 6;
        return pos;
    }
}
