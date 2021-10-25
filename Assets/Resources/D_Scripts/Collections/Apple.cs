using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private Animator _animator;
    private CollectionData userData;

    private CollectionCotroller CollectionCotroller;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        CollectionCotroller = FindObjectOfType<CollectionCotroller>();
        // userData = new CollectionData();
        // userData.AppleCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // AddAppleCount();
            _animator.SetTrigger("isPlayer");
            AudioManager.PlayAudio(AudioName.CollectCoin);
        }
    }

    //animation event
    public void DestroyApple()
    {
        // AddAppleCount();
        CollectionCotroller.AddAppleCount();
        Destroy(gameObject);
    }
    
    // public void AddAppleCount()
    // {
    //     userData.AppleCount += 1;
    // }
}
