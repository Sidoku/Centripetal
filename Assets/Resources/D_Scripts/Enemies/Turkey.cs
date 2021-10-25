using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turkey : MonoBehaviour
{
    public Transform groundCheckPoint;
    public float checkRadius;
    public LayerMask groundLayer;
    public GameObject platform;
    private Animator _animator;
    private Rigidbody2D rd;
    private bool isGround;
    public bool isPlayer;
    
    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("ground",isGround);
        _animator.SetBool("isPlayer",isPlayer);
        _animator.SetFloat("velocityY",_rigidbody2D.velocity.y);
    }

    private void FixedUpdate()
    {
        var position = groundCheckPoint.position;
        isGround = Physics2D.OverlapCircle(position, checkRadius, groundLayer);
        if (isPlayer)
        {
            rd.bodyType = RigidbodyType2D.Dynamic;
        }

        if (isGround)
        {
            rd.bodyType = RigidbodyType2D.Static;
        }
    }
    
    //animation event
    public void Dead()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            // Destroy(gameObject);
            Destroy(transform.parent.gameObject);
            Instantiate(platform, transform.position,Quaternion.identity);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.Instance.isDead = true;
        }
    }
    
}
