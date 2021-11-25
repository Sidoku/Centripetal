using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurkeyTriggerPoint : MonoBehaviour
{
    private Turkey turkey;

    private void Start()
    {
        turkey = transform.parent.GetChild(0).GetComponent<Turkey>();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            turkey.isPlayer = true;
            Destroy(gameObject);
        }
    }
}
