using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject prototypePlatform;
    private List<GameObject> platformList = new List<GameObject>();

    public void SpawnPlatform(GameObject platformType)
    {
        platformUp();
        GameObject newPlatform = Instantiate(platformType, GetPlatformPosition(), transform.rotation);
        newPlatform.transform.parent = gameObject.transform;

        platformList.Add(newPlatform);
    }

    public void platformUp()
    {
        foreach (GameObject platform in platformList)
        {
            platform.GetComponent<Rigidbody2D>().AddForce(transform.up * 2000);
        }
    }

    public float GetStackHeight()
    {
        return prototypePlatform.GetComponent<Renderer>().bounds.size.y * prototypePlatform.transform.localScale.y * platformList.Count;
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
        pos.y = -6;
        return pos;
    }
}
