using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscendingSlide : MonoBehaviour
{
    public PhysicsMaterial2D fiction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // if (PlayerController.Instance.horizontalInput > 0f)
            // {
            //     other.GetComponent<BoxCollider2D>().sharedMaterial = null;
            // }
            // else
            // {
            //     other.GetComponent<BoxCollider2D>().sharedMaterial = fiction;
            // }
            other.GetComponent<BoxCollider2D>().sharedMaterial = fiction;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerController.Instance.horizontalInput > 0f)
            {
                other.GetComponent<BoxCollider2D>().sharedMaterial = null;
            }
            else
            {
                other.GetComponent<BoxCollider2D>().sharedMaterial = fiction;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BoxCollider2D>().sharedMaterial = null;
        }
    }
}
