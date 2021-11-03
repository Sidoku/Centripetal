using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (!PlayerController.Instance.hasBag)
                return;
            // gameObject.layer = LayerMask.NameToLayer("CollectionTrigger");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
