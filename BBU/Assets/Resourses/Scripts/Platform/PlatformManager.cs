using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private GameObject newPlatform;

    public void SpawnPlatform(GameObject platformType)
    {
        newPlatform = Instantiate(platformType, GetPlatformPosition(), transform.rotation);
        newPlatform.transform.parent = gameObject.transform;
    }

    public Vector2 GetPlatformPosition()
    {
        Vector2 pos;
        pos.x = 0;
        pos.y = -6;
        return pos;
    }
}
