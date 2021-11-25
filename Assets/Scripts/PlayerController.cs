using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player in the room")]
    // public GameObject Bag;
    public static PlayerController Instance;

    public float speed, jumpForce;
    //public int playerGravityScale;
    // [Header("Player State")] 
    // public float health;
    // public bool isDead;

    [Header("States Check")] public bool isGround;
    public bool isJump;
    public bool canJump;

    // public bool isPlatform;
    [Header("Ground Check")] public Transform groundCheck;
    public LayerMask groundLayer, slopeLayer;
    public float checkRadius;
    [Header("FX Check")] 
    public GameObject jumpFX;
    public GameObject fallFX;
    public GameObject dashFX;
    public GameObject leftRunFX;

    [Header("Slope Function")] public float slopeCheckDistance;

    private Vector2 colliderSize;
    private Vector2 newVelocity; //new move & jump method
    private Vector2 newForce;
    private float slopeDownAngle;
    private float slopeDownAngleOld;
    private float slopeSideAngle;
    private Vector2 slopeNormalPerpendicular;

    [SerializeField] 
    private bool isOnSlope;
    private bool isJumping;
    private CapsuleCollider2D bc2D;
    private Vector2 oldPosition;

    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D fullFriction;

    private bool banMovement;

    

    #region Sid's movement

    InputMaster controls;

    public Vector2 move;

    //bool jump;
    //bool boost;
    public int boost;
    public bool isClickedBoost;

    public float boostForce;
    private float moveInput;

    public int jumps;
    public int maxJumps = 2;
    public int maxBoost = 1;

    #endregion

    #region private members
    
    private MessageTest _messageTest;
    public Rigidbody2D rb;
    private Animator _animator;
    [Header("Boundary Animator")]
    // public Animator boundaryAnimator;
    public float horizontalInput;

    #endregion
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
        Instance = this;
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

    void Start()
    {
        isClickedBoost = false;
        _messageTest = FindObjectOfType<MessageTest>();
        // Bag.SetActive(false);
        bc2D = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        colliderSize = bc2D.size;
        // boundaryAnimator = GetComponent<Animator>();

    }
    
    private void FixedUpdate()
    {
        if (banMovement)
        {
            return;   
        }
        rb.AddForce(new Vector2(move.x * speed * Time.fixedDeltaTime, 0), ForceMode2D.Impulse);
        PhysicsCheck();
        Movement();
        SlopeCheck();
        
        //calculate speed here
        var currentSpeed = Vector2.Distance(oldPosition, transform.position) * 100f;
        oldPosition = transform.position;
        //if currentSpeed > 50, play rotate animation
    }
    
    private void Movement()
    {
        if (move.x == 0)
        {
            leftRunFX.SetActive(false);
        }

        if (move.x != 0 && isGround)
        {
            leftRunFX.SetActive(true);
            if (move.x > 0)
            {
                move.x = 1;
                transform.localScale = new Vector3(Mathf.Abs(move.x * transform.localScale.x), transform.localScale.y, transform.localScale.z);
                // transform.localScale = new Vector3(move.x,1,1);
            }
            else if (move.x < 0)
            {
                move.x = -1;
                // transform.eulerAngles = new Vector3(0, 180, 0);
                transform.localScale = new Vector3(Mathf.Abs(move.x * transform.localScale.x) * -1,
                    transform.localScale.y, transform.localScale.z);
            }
            
            // transform.localScale = new Vector3(move.x, 1, 1);
            // transform.rotation
        }
        else if (move.x > 0 && isJump)
        {
            // transform.localScale = new Vector3(move.x, 1, 1);
            leftRunFX.SetActive(false);
        }

        if (isOnSlope && !canJump)
        {
            rb.AddForce(new Vector2(-move.x * speed * slopeNormalPerpendicular.x * Time.fixedDeltaTime, -move.x * speed * slopeNormalPerpendicular.y * Time.fixedDeltaTime), ForceMode2D.Impulse);
            // newVelocity.Set(-move.x * speed * slopeNormalPerpendicular.x, -move.x * speed * slopeNormalPerpendicular.y);
            // // newVelocity.Set(-move.x * speed * slopeNormalPerpendicular.x * Time.fixedDeltaTime, -move.x * speed * slopeNormalPerpendicular.y * Time.fixedDeltaTime);
            // rb.velocity = newVelocity;
        }
    }

    void Jump()
    {
        if (jumps == 0)
        {
            return;
        }

        if (jumps > 0)
        {
            //xue qing's version
            isJump = true;
            canJump = true;
            jumpFX.SetActive(true);
            jumpFX.transform.position = transform.position + new Vector3(0, -0.45f, 0);
            Vector2 v2Velocity = rb.velocity;
            rb.velocity = new Vector2(move.x, 0); // stops player from falling down, allowing for a verticle jump when falling
            rb.velocity = new Vector2(move.x + v2Velocity.x, jumpForce * 100 * Time.fixedDeltaTime);
            //rb.gravityScale = playerGravityScale;
            jumps--;
        }
    }
    
    public void FallFXFinish() //animation event
    {
        fallFX.SetActive(true);
        fallFX.transform.position = transform.position + new Vector3(0, -0.75f, 0);
    }

    private void PhysicsCheck()
    {
        var position = groundCheck.position;
        // var position1 = platformCheck.transform.position;
        isGround = Physics2D.OverlapCircle(position, checkRadius, groundLayer)
                   || Physics2D.OverlapCircle(position, checkRadius, slopeLayer);
        // isPlatform = Physics2D.OverlapCircle(position1, 0.02f, platformLayer);
        if (isGround)
        {
            //rb.gravityScale = 1;
            isJump = false;
            // jumpTwice = false;
        }
       /* else if (!isJump && !isGround) //上平台之后修复重力变成1
        {
            rb.gravityScale = playerGravityScale;
        }*/

        if (rb.velocity.y <= 0.0f)
        {
            canJump = false;
        }

        // else if (isOnSlope && !isGround)
        // {
        //     rb.gravityScale = 100;
        // }
        // if (hit.collider.CompareTag("Wall"))
        // {
        //     Debug.DrawRay(transform.position,grabDir);
        // }
    }
    

    #region Slope Logic

    private void SlopeCheck()
    {
        Vector2 checkPos = transform.position - new Vector3(0, colliderSize.y / 2);
        SlopeCheckVertical(checkPos);
        SlopeCheckHorizontal(checkPos);
    }

    private void SlopeCheckHorizontal(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, transform.right, slopeCheckDistance, slopeLayer);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -transform.right, slopeCheckDistance, slopeLayer);
        if (slopeHitFront)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
        }
        else if (slopeHitBack)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        }
        else
        {
            slopeSideAngle = 0f;
            isOnSlope = false;
        }
    }

    private void SlopeCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, slopeLayer);
        if (hit)
        {
            slopeNormalPerpendicular = Vector2.Perpendicular(hit.normal).normalized;

            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up); //angle between x-axis and the slope y-axis

            if (slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;

            Debug.DrawRay(hit.point, slopeNormalPerpendicular, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.blue);
        }

        if (isOnSlope && move.x == 0f)
        {
            rb.sharedMaterial = fullFriction;
        }
        else
        {
            rb.sharedMaterial = noFriction;
        }
    }

    #endregion

    #region Sid's logic

    private void Boost() //Changed boost to be a int rather than bool. We can maybe make a level with multiple boosts
    {
        
        if (boost > 0)
        {
            dashFX.SetActive(true);
            
            isClickedBoost = true;
            Vector2 v2Velocity01 = rb.velocity;
            if (move.x < 0) //move.x is positive when moving right, move.x is negative when moving left
            {
                
                rb.velocity = Vector2.left * boostForce + v2Velocity01;
                dashFX.transform.position = transform.position + new Vector3(3f, 0, 0);
            }
            else
            {
                rb.velocity = Vector2.right * boostForce + v2Velocity01;
                dashFX.transform.position = transform.position + new Vector3(-3f, 0, 0);
            }
            boost--;
        }

    }
    
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Slope" ||
            collider.gameObject.tag == "SpeedZone")
        {
            jumps = maxJumps;
            boost = maxBoost;
        }

        if (collider.gameObject.tag =="Glass")
        {
            collider.gameObject.GetComponent<Animator>().SetTrigger("isPlayer");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // switch (other.transform.name)
        // {
        //     
        // }
        if (other.transform.gameObject.tag =="Glass")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("isPlayer");
            Debug.Log("1");
        }
        if (other.transform.gameObject.tag =="Ground")
        {
            jumps = maxJumps;
            boost = maxBoost;
        }
        if (other.transform.name.StartsWith("Ripple"))
        {
            banMovement = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.name.StartsWith("Ripple"))
        {
            banMovement = false;
        }
    }

    #endregion
    
}