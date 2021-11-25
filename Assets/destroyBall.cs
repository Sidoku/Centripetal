using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBall : MonoBehaviour
{
    public float destroyDelay = 6f;
    void DestroyObjectDelayed()
    {
        Destroy(gameObject, destroyDelay);
    }
}
