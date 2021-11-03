using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    public CollectionAndDoors CollectionAndDoors;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            CollectionAndDoors.itemList.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
