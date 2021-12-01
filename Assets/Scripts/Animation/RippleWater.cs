using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleWater : MonoBehaviour
{
    public Transform startPoint;
    public int moveSpeed;
    public bool isPlayer;

    void Start()
    {
        var destinationPoint = new Vector2(startPoint.transform.position.x, PlayerController.Instance.transform.position.y);
    }
    void Update()
    {
        if (isPlayer)
        {
            var destinationPoint = new Vector2(startPoint.transform.position.x, PlayerController.Instance.transform.position.y);
            PlayerController.Instance.transform.position = Vector2.MoveTowards(PlayerController.Instance.transform.position,
                destinationPoint, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(PlayerController.Instance.transform.position, destinationPoint) < 0.2f)
            {
                // isPlayer = false;
                PlayerController.Instance.transform.position = destinationPoint;
            }
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
            PlayerController.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.GetComponent<Animator>().SetBool("isPlayer",isPlayer);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = false;
            gameObject.GetComponent<Animator>().SetBool("isPlayer",isPlayer);
            PlayerController.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    public void PlayRippleAudio()
    {
        AudioManager.PlayAudio(AudioName.Water);
    }

}
