using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yoyoRotation : MonoBehaviour
{
    public bool isCaught;
    public bool isWall;
    
    public float CheckRadius;
    
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(new Vector3(0,0,-20f));
        if (isWall)
        {
            Mechanics.Instance.destinationPoint = Mechanics.Instance.transform.position;
        }
    }

    private void FixedUpdate()
    {
        //when the yoyo hits the wall, it should return back, not through the wall!!!
        //when hits the wall, set destinationPoint to the player
        isWall = Physics2D.OverlapCircle(transform.position, CheckRadius, groundLayer) ||
                 Physics2D.OverlapCircle(transform.position, CheckRadius, LayerMask.NameToLayer("Slope"));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Breakfast") && Mechanics.Instance.isMechanic_1)
        {
            other.transform.parent = transform;
            // other.transform.rotation = Quaternion. Euler (0.0f, 0.0f, other.transform.rotation. z * -1.0f);
        }
    }
}
