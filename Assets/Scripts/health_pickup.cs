using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_pickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            collision.GetComponent<player>().heal();
            Destroy(this.gameObject);
        }
    }
}
