using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public bool isWall;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Wall"))
        {
            isWall = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Wall"))
        {
            isWall = false;
        }
    }
}
