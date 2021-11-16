using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBus : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bus")
        {
            Destroy(gameObject);
        }
    }
}
