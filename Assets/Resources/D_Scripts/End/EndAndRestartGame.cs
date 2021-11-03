using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndAndRestartGame : MonoBehaviour
{
    public GameObject EndMenu;
    public DisappearStartMenu DisappearStartMenu;
    public Text appleNumber,appleCoin;
    public Text bananaNumber,bananaCoin;
    public Text coinNumber;

    
    private Animator _animator;
    private CollectionCotroller _collectionCotroller;
    
    // Start is called before the first frame update
    

    void Start()
    {
        DisappearStartMenu = FindObjectOfType<DisappearStartMenu>();
        _animator = GetComponent<Animator>();
        EndMenu.SetActive(false);
        _collectionCotroller = FindObjectOfType<CollectionCotroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _animator.SetTrigger("isPlayer");
            EndMenu.SetActive(true);
            // DisappearStartMenu.Apple.SetActive(false);
            DisappearStartMenu.Apple.GetComponentInChildren<Text>().DOFade(0, 1f);
            DisappearStartMenu.Apple.GetComponentInChildren<Image>().DOFade(0, 1f);
            // DisappearStartMenu.Banana.SetActive(false);
            DisappearStartMenu.Banana.GetComponentInChildren<Text>().DOFade(0, 1f);
            DisappearStartMenu.Banana.GetComponentInChildren<Image>().DOFade(0, 1f);
            DisappearStartMenu.Coin.GetComponentInChildren<Text>().DOFade(0, 1f);
            DisappearStartMenu.Coin.GetComponent<Image>().DOFade(0, 1f);

            appleNumber.text = _collectionCotroller.appleText.text;
            bananaNumber.text = _collectionCotroller.bananaText.text;
            int apple = Int32.Parse(_collectionCotroller.appleText.text) * 2;
            int banana = Int32.Parse(_collectionCotroller.bananaText.text) * 3;
            appleCoin.text = apple.ToString();
            bananaCoin.text = banana.ToString();
            if (PlayerPrefs.HasKey("CoinNumber"))
            {
                int currentCoin = PlayerPrefs.GetInt("CoinNumber");
                PlayerPrefs.SetInt("CoinNumber", apple + banana + currentCoin);
            }
            coinNumber.text = PlayerPrefs.GetInt("CoinNumber").ToString();
            PlayerPrefs.Save();
            // appleCoin.text = _collectionCotroller
        }
    }

    //restart button event  
    public void RestartScene()
    {
        SceneManager.LoadScene("D_01");
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.collider.CompareTag("Player"))
    //     {
    //         _animator.SetTrigger("isPlayer");
    //         
    //     }
    // }
}
