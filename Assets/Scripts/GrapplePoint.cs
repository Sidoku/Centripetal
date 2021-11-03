using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    private GrapplingGun _grappling;
    void Start()
    {
        _grappling = FindObjectOfType<GrapplingGun>();
    }

    private void OnMouseDown()
    {
        
    }
}
