using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFindYoyo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.Instance.hasYoyo = true;
            Destroy(gameObject);
        }
    }
}
