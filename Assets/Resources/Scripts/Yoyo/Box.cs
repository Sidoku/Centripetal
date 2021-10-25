using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public GameObject tempYoyo;
    public bool isYoyo;
    private Vector2 boxVector2;
    private Vector2 yoyoPosition;


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
        if (other.collider.CompareTag("Yoyo"))
        {
            isYoyo = true;
        }
    }
    
}
