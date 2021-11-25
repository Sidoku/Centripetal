using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int ID;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (ID)
            {
                case 1:
                    CheckLists.Instance.destinationPoint = CheckLists.Instance.Collider2Ds[0].transform.position;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    _animator.SetBool("isPlayer",true);
                    break;
                case 2:
                    CheckLists.Instance.destinationPoint = CheckLists.Instance.Collider2Ds[1].transform.position;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    _animator.SetBool("isPlayer",true);
                    break;
                case 3:
                    CheckLists.Instance.destinationPoint = CheckLists.Instance.Collider2Ds[2].transform.position;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    _animator.SetBool("isPlayer",true);
                    break;
            }
        }
    }
}
