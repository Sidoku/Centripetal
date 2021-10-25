using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_PatrolState : D_EnemyState
{
    public override void D_EnterState(AllEnemies enemy)
    {
        enemy.animState = 1;
        enemy.SwitchPoint();// get target point
        // enemy.MoveToTarget();//move to target point, when arrived at the point, flip itself and change target again!!
    }

    public override void D_OnUpdate(AllEnemies enemy)
    {
        
        if (!enemy._animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            // enemy.animState = 0;
            enemy.MoveToTarget();
            while (Mathf.Abs(enemy.targetPoint.transform.position.x - enemy.transform.position.x) < 0.01f)
            {
                enemy.TransitionToState(enemy.PatrolState);
                // enemy.animState = 0;
                enemy.SwitchPoint();
            }
        }
        
    }
}
