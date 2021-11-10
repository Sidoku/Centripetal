using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEnemy : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            _animator.SetTrigger("hit");
            PlayerController.Instance.GetComponent<Rigidbody2D>().velocity =
                new Vector2(PlayerController.Instance.transform.position.x, 20f);
        }
    }
}
