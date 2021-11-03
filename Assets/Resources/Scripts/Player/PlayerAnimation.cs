using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController _controller;
    private Animator _animator;

    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("speed",Mathf.Abs(_rigidbody2D.velocity.x));
        // _animator.SetFloat("velocityY",_rigidbody2D.velocity.y);
        //_animator.SetBool("jump2",_controller.jumpTwice);
        // _animator.SetBool("jump",_controller.isJump);
        // _animator.SetBool("ground",_controller.isGround);
    }
}
