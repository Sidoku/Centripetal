using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarnSignTrigger : MonoBehaviour
{

    public Transform NewFollowTransform;
    // public CinemachineVirtualCamera vCamera;

    private int isPlayer;

    private MessageTest test;
    
    private void Start()
    {
        
        test = FindObjectOfType<MessageTest>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // isPlayer = true;
            test.ChangePlayerStatus();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Camera.main.orthographicSize = 10;
            Camera.main.transform.parent = null;
            Camera.main.transform.position = transform.position + new Vector3(10, 0, 0);
            
        }
    }
    
}
