using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainPoint : MonoBehaviour
{
    private double destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = gameObject.transform.position.y + 0.5;
        Invoke("End", 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime;
    }

    private void End()
    {
        Destroy(gameObject);
    }
}
