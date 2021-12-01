using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    // Input 
    private int clickTime;
    private InputMaster controls;
    // Start is called before the first frame update
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    
    private void OnDisable()
    {
        controls.Player.Disable();
    }
    
    private void Awake()
    {
        controls = new InputMaster();
    }

    private void Update()
    {
        controls.Player.Pause.performed += ctx => ShowPauseMenu();
       
    }

    //event function
    public void RestartLevel()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                PlayerController.Instance.transform.position = new Vector3(13, 6, -1).normalized;
                break;
            case 1:
                break;
        }
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        clickTime = 0;
    }
    
    private void ShowPauseMenu()
    {
        if (clickTime == 0)
        {
            pauseMenu.gameObject.SetActive(true);
            AudioManager.StopAudio(AudioName.BGM);
            Time.timeScale = 0;
            clickTime++;
        }
        else if (clickTime == 1)
        {
            pauseMenu.gameObject.SetActive(false);
            AudioManager.PlayAudio(AudioName.BGM);
            Time.timeScale = 1;
            clickTime = 0;
        }
       
       
    }
    
}
