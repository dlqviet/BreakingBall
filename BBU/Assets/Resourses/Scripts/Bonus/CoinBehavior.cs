using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public float existDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.transform.parent.gameObject.GetComponent<CoinManager>().CollectCoin(1);
            Destroy(gameObject);
        }
    }

    private void Die()
    {
        CancelInvoke();
        Destroy(gameObject);
    }

    private void Start()
    {
        Invoke("Die", existDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
