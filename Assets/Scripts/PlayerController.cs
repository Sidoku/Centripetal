using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputMaster controls;
    Vector2 move;
    //bool jump;
    bool boost;

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float boostForce;
    private float moveInput;

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
        //controls.Player.Jump.canceled += ctx => jump = false;

        controls.Player.Boost.performed += ctx => this.Boost();
        controls.Player.Boost.canceled += ctx => boost = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Boost()
    {
        if (boost == true)
        {                               //move.x is positive when moving right, move.x is negative when moving left
            if (move.x < 0)
            {
                rb.velocity = Vector2.left * boostForce;
            }
            else
            {
                rb.velocity = Vector2.right * boostForce;
            }
            boost = false;
        }
    }

    private void Jump()
    {
        if (jumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
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
            boost = true;
        }
    }

    private void FixedUpdate()
    {
        // rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
    }
}
