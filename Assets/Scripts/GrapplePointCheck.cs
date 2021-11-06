using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrapplePointCheck : MonoBehaviour
{
    public bool isGrapplePoint;

    public int checkRadius;

    public LayerMask grappleLayerMask;

    private GrapplingGun _grapplingGun;
    // Start is called before the first frame update
    void Start()
    {
        _grapplingGun = FindObjectOfType<GrapplingGun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RadiusCheckGrapplePoint();
    }

    void RadiusCheckGrapplePoint()
    {
        isGrapplePoint = Physics2D.OverlapCircle(transform.position, checkRadius, grappleLayerMask);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.name);
        if (other.name.StartsWith("Grapple"))
        {
            other.gameObject.GetComponent<Animator>().SetBool("canGrapple",true);
            // if (_grapplingGun.isGrappled)
            // {
            //     other.gameObject.GetComponent<Animator>().SetTrigger("isGrappled");
            // }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name.StartsWith("Grapple"))
        {
            other.gameObject.GetComponent<Animator>().SetBool("canGrapple",false);
        }
    }
}
