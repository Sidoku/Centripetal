using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLists : MonoBehaviour
{
    public static CheckLists Instance;
    public GameObject[] checkPoints;
    public BoxCollider2D[] Collider2Ds;
    public Vector3 destinationPoint;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Collider2Ds = new BoxCollider2D[checkPoints.Length];
        for (int i = 0; i < Collider2Ds.Length; i++)
        {
            Collider2Ds[i] = checkPoints[i].GetComponent<BoxCollider2D>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
