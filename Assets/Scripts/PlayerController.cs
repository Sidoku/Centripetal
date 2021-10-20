using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputMaster controls;
    Vector2 move;
    //bool jump;
    //bool boost;
    public int boost;

    
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float boostForce;
    private float moveInput;

    public int jumps;
    public int maxJumps = 2;
    public int maxBoost = 1;






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
        //controls.Player.Boost.canceled += ctx => boost = false; //removed ability to cancel boost, was doing it too often

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

    private void FixedUpdate() //made this public and moved it from the bottom
    {
            rb.AddForce(new Vector2(move.x * speed * Time.fixedDeltaTime, move.y), ForceMode2D.Impulse);
    }

    private void Boost() //Changed boost to be a int rather than bool. We can maybe make a level with multiple boosts
    {
        if (boost > 0)
        {
            Vector2 v2Velocity01 = rb.velocity;
            if (move.x < 0) //move.x is positive when moving right, move.x is negative when moving left
            {
                
                rb.velocity = Vector2.left * boostForce + v2Velocity01;
            }
            else
            {
                rb.velocity = Vector2.right * boostForce + v2Velocity01;
            }
            boost--;
        }
    }

    
    private void Jump()
    {
        if (jumps > 0)
        {
            //Rigidbody rb = GetComponent<Rigidbody>();
            Vector2 v2Velocity = rb.velocity;
            rb.velocity = new Vector2(move.x, 0); // stops player from falling down, allowing for a verticle jump when falling
            rb.velocity = new Vector2(move.x + v2Velocity.x, jumpForce * 100 * Time.fixedDeltaTime);
            Debug.Log("Jump");
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
    boost = maxBoost;
}
}


}
