using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour
{
    public GrapplingGun _grappling;
    void Start()
    {
        _grappling = FindObjectOfType<GrapplingGun>();
        
        GameController.Instance.grapplePoints.Add(gameObject.transform.parent);//add all points to the list, when player click, check which point is most close to the player, then grapple it.
    }

    private void OnMouseDown()
    {
        _grappling.DestinationPoint = gameObject.transform.position;
        Debug.Log(_grappling.DestinationPoint);
    }
    
    
}
