using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputMaster controls;
    Vector2 move;
    bool jump;

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public int jumps;
    public int maxJumps = 2;


    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
    private void Awake()
    {
        controls = new InputMaster();

        //Horizontal movement controls
        controls.Player.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Movement.canceled += ctx => move = Vector2.zero;

        //Jump
        controls.Player.Jump.performed += ctx => this.Jump();
        controls.Player.Jump.canceled += ctx => jump = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(jump == true)
        {
            this.Jump();
        }*/
        /*isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);
        if (isGrounded == true && jump == true)
        {
            Debug.Log("isGround" + isGrounded);
            isjumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if (jump == true && isjumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isjumping = false;
            }

        }

        if (jump == false)
        {
            isjumping = false;
        }*/


    }

    private void Jump()
    {
        if (jumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            jumps--;
        }
        if (jumps == 0)
        {
            return;
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            jumps = maxJumps;
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        // rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
    }
}
