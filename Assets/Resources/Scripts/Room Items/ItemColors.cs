using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColors : MonoBehaviour
{
    // public string colorName;
    // public CollectionAndDoors CollectionAndDoors;
    // private void Awake()
    // {
    //     CollectionAndDoors = FindObjectOfType<CollectionAndDoors>();
    // }
    public CollectionAndDoors CollectionAndDoors;
    // Start is called before the first frame update
    void Start()
    {
        CollectionAndDoors = new CollectionAndDoors();
        // CollectionAndDoors.c_Dictionary.Add(colorNumber,gameObject);
        // CollectionAndDoors.Instance.c_Dictionary.Add(colorName,gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectionAndDoors.itemList.Remove(gameObject);
        }
    }
}
