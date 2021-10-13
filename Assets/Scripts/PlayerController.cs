using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputMaster controls;

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public bool isjumping;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask WhatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;

    private void Awake()
    {
        controls = new InputMaster();

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isjumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if(Input.GetKey(KeyCode.Space) && isjumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isjumping = false;
            }
           
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isjumping = false;
        }
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
}
