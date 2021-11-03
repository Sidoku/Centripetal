using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCollections : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // var getFirstName = other.collider.name;
        // switch (getFirstName)
        // {
        //     case "Breakfast":
        //         if (other.transform.CompareTag("Player"))
        //         {
        //             Destroy(gameObject);
        //             Debug.Log("Breakfast collectec");
        //         }
        //         break;
        // }
        var colliderName = other.collider.name;
        switch (colliderName)
        {
            case "YOYO":
                Mechanics.Instance.destinationPoint = PlayerController.Instance.transform.position;
                break;
        }
    }
}