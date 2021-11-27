using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDontDestroyOnLoad : MonoBehaviour
{
    private static UIDontDestroyOnLoad instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
       
    }
}
