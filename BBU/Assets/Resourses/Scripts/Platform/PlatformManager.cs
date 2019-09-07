using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private Queue<GameObject> platformQueue = new Queue<GameObject>();

    public void SpawnPlatform(GameObject platformType)
    {
        GameObject newPlatform = Instantiate(platformType, GetPlatformPosition(), transform.rotation);
        newPlatform.transform.parent = gameObject.transform;
        platformQueue.Enqueue(newPlatform);
    }

    public Vector2 GetPlatformPosition()
    {
        Vector2 pos;
        pos.x = 0;
        pos.y = 1.2f * platformQueue.Count - 6;
        return pos;
    }
}
