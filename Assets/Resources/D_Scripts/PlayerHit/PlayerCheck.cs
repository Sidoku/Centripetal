using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(PlayerCome());
        }
    }

    IEnumerator PlayerCome()
    {
        yield return new WaitForSeconds(1f);
        transform.GetComponentInParent<Animator>().SetBool("isPlayer",true);
        yield return new WaitForSeconds(3f);
        transform.GetComponentInParent<Animator>().SetBool("isPlayer",false);
    }
}
