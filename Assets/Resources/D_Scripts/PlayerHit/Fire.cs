using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int fireType;
    private bool isPlayer;
    private float time;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            time += Time.deltaTime;
            if (time > 1f)
            {
                isPlayer = true;
                _animator.SetBool("isPlayer",true);
                PlayerController.Instance.isDead = true;
                StartCoroutine("PlayerCome");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            time = 0f;
        }
    }

    IEnumerator PlayerCome()
    {
        yield return new WaitForSeconds(3f);
        time = 0f;
        transform.GetComponentInParent<Animator>().SetBool("isPlayer",false);
    }
}
