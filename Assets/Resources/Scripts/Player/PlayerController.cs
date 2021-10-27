using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [Header("Player in the room")] 
    // public GameObject Bag;
    public bool hasBag;
    public bool hasYoyo;
    public static PlayerController Instance;
    public float speed, jumpForce;
    public int slopeSpeed;
    public int speedZoneSpeed;
    public int playerGravityScale;
    [Header("Player State")] 
    public float health;
    public bool isDead;
    
    [Header("States Check")] 
    public bool isGround;
    public bool isJump;
    public bool canJump;
    public bool canJump2;
    public bool jumpTwice;
    public bool isIdle;
    public bool isPlatform;
    [Header("Ground Check")] 
    
    public Transform groundCheck,platformCheck;
    public LayerMask groundLayer, platformLayer,slopeLayer;
    public float downTime;
    public float checkRadius;
    [Header("FX Check")] 
    
    public GameObject jumpFX;
    public GameObject fallFX;
    public GameObject leftRunFX;
    [Header("Wall Run")] 
    public float playerHeight;

    [Header("Slope Function")] 
    public float slopeCheckDistance;
    public float slopeCheckDistanceHorizontal;
    public GameObject wallCheckPoint;

    [SerializeField] 
    private Vector2 colliderSize;

    private Vector2 newVelocity;//new move & jump method
    private Vector2 newForce;
    private float slopeDownAngle;
    private float slopeDownAngleOld;
    private float slopeSideAngle;
    private Vector2 slopeNormalPerpendicular;
    
    [SerializeField]
    private bool isOnSlope;

    private bool isJumping;

    public PhysicsMaterial2D noFriction;
    public PhysicsMaterial2D fullFriction;

    private CapsuleCollider2D bc2D;

    #region Sid's movement

    InputMaster controls;
    Vector2 move;
    //bool jump;
    //bool boost;
    public int boost;

    public float boostForce;
    private float moveInput;

    public int jumps;
    public int maxJumps = 2;
    public int maxBoost = 1;
    

    #endregion
    #region private members

    private MessageTest _messageTest;
    private Rigidbody2D rb;
    private Animator _animator;
    public float horizontalInput;
    public float verticalInput;
    
    private int animationCount;
    #endregion

    //买了几个技能的判断
    // private int _purchasedSkill;
    
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
        _messageTest = FindObjectOfType<MessageTest>();
        // Bag.SetActive(false);
        bc2D = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        colliderSize = bc2D.size;
    }

    void Update()
    {
        // if (isDead)
        // {
        //     // _animator.SetBool("dead",isDead);
        //     _animator.SetTrigger("Dead");
        //     return;
        // }
        // InputCheck();
        if (_messageTest.isPlayer == 1)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            playerGravityScale = 8;
        }
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (isDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        PhysicsCheck();
        // if (Mechanics.Instance.isMechanic_2)
        // {
        //     return;
        // }
        Movement();
        SlopeCheck();
    }

    private void InputCheck()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround || isOnSlope)
            {
                Jump();
                canJump = true;
                canJump2 = true;
            }
            // else if (canJump2)
            // {
            //     JumpTwice();
            //     canJump2 = false;
            //     jumpFX.SetActive(false);
            // }
            
        }
        
        if (Input.GetButtonDown("Vertical"))
        {
            IsPlatform();
        }
    }

    private void Movement()
    {
        // if (isGround)
        // {
        //     rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        // }
        //
        // if (isGround && isOnSlope)
        // {
        //     // newVelocity.Set(horizontalInput * speed, rb.velocity.y);
        //     newVelocity.Set(-horizontalInput * speed * slopeNormalPerpendicular.x, horizontalInput * speed * slopeNormalPerpendicular.y);
        //     rb.velocity = newVelocity;
        // }
        
        // newVelocity.Set(horizontalInput * speed, rb.velocity.y);
        // rb.velocity = newVelocity;


        if (horizontalInput == 0)
        {
            leftRunFX.SetActive(false);
        }

        if (horizontalInput != 0 && isGround)
        {
            leftRunFX.SetActive(true);
            transform.localScale = new Vector3(horizontalInput, 1, 1);
        }
        else if (horizontalInput != 0 && isJump)
        {
            transform.localScale = new Vector3(horizontalInput, 1, 1);
            leftRunFX.SetActive(false);
        }
        // else if (horizontalInput != 0 && !isGround)
        // {
        //     leftRunFX.SetActive(false);
        // }

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        
        //slope judgement
         // if (isGround)
         // {
         //     newVelocity.Set(horizontalInput * speed, rb.velocity.y);
         //     rb.velocity = newVelocity;
         //     Debug.Log("111");
         // }
         if (isOnSlope && !canJump)
         {
             newVelocity.Set(-horizontalInput * speed * slopeNormalPerpendicular.x, -horizontalInput * speed * slopeNormalPerpendicular.y);
             rb.velocity = newVelocity;
             Debug.Log("22");
             //infinity jump method
         }
         // else if (!isGround)
         // {
         //     newVelocity.Set(horizontalInput * speed, rb.velocity.y);
         //     rb.velocity = newVelocity;
         //     Debug.Log("33");
         // }
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
            newVelocity.Set(0, 0);
            rb.velocity = newVelocity;
            newForce.Set(0,jumpForce);
            rb.AddForce(newForce,ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.gravityScale = playerGravityScale;
            //---
            //sid's version
            // Vector2 v2Velocity = rb.velocity;
            // rb.velocity = new Vector2(move.x, 0); // stops player from falling down, allowing for a verticle jump when falling
            // rb.velocity = new Vector2(move.x + v2Velocity.x, jumpForce * 100 * Time.fixedDeltaTime);
            // Debug.Log("Jump");
            jumps--;
        }
    }
    

    void WallRunCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(2, 0), 2f,groundLayer);
        if (!hit.collider.CompareTag("Wall"))
            return;
        Debug.Log("hello"); 
        _animator.SetTrigger("wallJump");

        // RaycastHit2D[] hit2D = Physics2D.RaycastAll(transform.position, new Vector2(0, -1f), groundLayer);
        // foreach (var items in hit2D)
        // {
        //     if (items.collider.CompareTag("Platforms"))
        //     {
        //         if (Mathf.Abs(transform.position.y - items.collider.transform.position.y) > 0)
        //         {
        //             Debug.Log(transform.position.y-items.collider.transform.position.y);
        //             items.collider.enabled = false;
        //             Debug.Log("player"+transform.position);
        //             Debug.Log("obj"+items.collider.transform.position);
        //         }
        //         items.collider.enabled = true;
        //         //     isPlatform = true;
        //       
        //     }
        // }
    }

    public void FallFXFinish()//animation event
    {
        fallFX.SetActive(true);
        fallFX.transform.position = transform.position + new Vector3(0, -0.75f, 0);
    }

    private void PhysicsCheck()
    {
        var position = groundCheck.position;
        var position1 = platformCheck.transform.position;
        isGround = Physics2D.OverlapCircle(position, checkRadius, groundLayer)
                   || Physics2D.OverlapCircle(position1, checkRadius, slopeLayer);
        isPlatform = Physics2D.OverlapCircle(position1, 0.02f, platformLayer);
        if (isGround)
        {
            rb.gravityScale = 1;
            isJump = false;
            jumpTwice = false;
        }
        else if (!isJump && !isGround)//上平台之后修复重力变成1
        {
            rb.gravityScale = playerGravityScale;
        }

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
    

    #region 下落检测方法

    private void IsPlatform()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (isPlatform && verticalInput == 0f)//按下了下落键
        {
            // _animator.SetTrigger("fall");
            gameObject.layer = LayerMask.NameToLayer("OneWayPlatform");
            Invoke(nameof(RestoreLayer),downTime);
        }
        
    }

    public void RestoreLayer()
    {
        isGround = false;
        if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }

    #endregion
    
    

    public void GetHit(float damage)
    {
        //玩家收到伤害之后播放完受伤动画之后再少血
        //算是可以模拟一个受伤之后无敌的效果
        if (!_animator.GetCurrentAnimatorStateInfo(1).IsName("player_hit"))
        {
            health -= damage;
            if (health < 1)
            {
                health = 0;
                isDead = true;
            }
            _animator.SetTrigger("hit");
        }
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

            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);//angle between x-axis and the slope y-axis

            if (slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;
            
            Debug.DrawRay(hit.point,slopeNormalPerpendicular,Color.red);
            Debug.DrawRay(hit.point,hit.normal,Color.blue);
        }
        
        if (isOnSlope && horizontalInput == 0f)
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
    
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Slope" || collider.gameObject.tag == "SpeedZone")
        {
            jumps = maxJumps;
            boost = maxBoost;
        }
        
        if (collider.gameObject.tag == "Ground")
        {
            speed = 12;
        }

        if (collider.gameObject.tag == "Slope")
        {
            speed = slopeSpeed;
        }

        if (collider.gameObject.CompareTag("SpeedZone"))
        {
            speed = speedZoneSpeed;
        }
    }

    #endregion

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            speed = 8;
        }
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Diamond"))//这么写是为了防止吃宝石数量错误 通过下面的调用来增加宝石数量。
    //     {
    //         other.GetComponent<Animator>().Play("DiamondCollected");//必须要这么写 否则会在吃宝石1的时候 触发宝石2的动画 然后报错宝石1的animator空引用
    //         
    //     }
    // }
    
    // public void CollectCoin()//在CollectCoin中使用
    // {
    //     CoinUI.instance.currentCoinNumber += 1;
    // }
}
