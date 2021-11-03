using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class D_EnemyState
{
    public abstract void D_EnterState(AllEnemies enemy);

    public abstract void D_OnUpdate(AllEnemies enemy);
}
