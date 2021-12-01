using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAnimationController : MonoBehaviour
{
    private Animator _animator;

    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("isClicked",_playerController.isClickedBoost);
        _animator.SetInteger("boost",_playerController.boost);
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("BtoR"))
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                _playerController.isClickedBoost = false;
            }
        }
        
    }
}
