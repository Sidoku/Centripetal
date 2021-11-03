using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBird : AllEnemies
{
    public Transform[] points;

    public GameObject platform;
    public int moveSpeed,i;

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region private method
    
    #endregion

    #region public method
    //animation event
    public void Dead()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            Destroy(gameObject);
            Instantiate(platform, transform.position,Quaternion.identity);
        }
    }

    #endregion
    
    
}
