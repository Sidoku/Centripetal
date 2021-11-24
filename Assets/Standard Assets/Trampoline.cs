using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public int jumpForce;
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
            Vector2 upVelocity = new Vector2(0, jumpForce);
            other.GetComponent<Rigidbody2D>().velocity = upVelocity;
            transform.GetComponentInParent<Animator>().SetTrigger("isPlayer");
        }
    }
}
