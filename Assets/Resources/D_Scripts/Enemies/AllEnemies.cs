using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemies : MonoBehaviour
{
    public readonly D_PatrolState PatrolState = new D_PatrolState();
    public GameObject platform;
    public D_EnemyState currentState;
    public int speed;
    public Transform targetPoint;
    public Transform pointA,pointB;
    [HideInInspector]
    public Animator _animator;
    public int animState;
    // Start is called before the first frame update

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        TransitionToState(PatrolState);
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetInteger("state",animState);
        currentState.D_OnUpdate(this);
    }

    public void TransitionToState(D_EnemyState state)
    {
        currentState = state;
        currentState.D_EnterState(this);
    }
    
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.Instance.isDead = true;
        }
    }

    public void SwitchPoint()
    {
        //自动计算离哪个点远 总是朝远的点走
        var position = transform.position;
        //TODO 目标会将展示牌作为目标
        targetPoint = Mathf.Abs(pointA.position.x - position.x) 
                      > Mathf.Abs(pointB.position.x - position.x) ? pointA : pointB;
    }
    
    private void FlipDirection()
    {
        //on the right side of the enemy
        transform.rotation = Quaternion.Euler(0f, transform.position.x < targetPoint.position.x 
            ? 180f : 0f, 0f);
    }
    
    public void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        FlipDirection();
    }
    
    //animation event
    public void Dead()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            Destroy(gameObject);
            Instantiate(platform, transform.position,Quaternion.identity);
        }
    }
}
