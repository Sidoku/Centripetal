using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject restartButton;
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
            case 1:
                PlayerController.Instance.transform.position = new Vector3(12,9,-0.8f);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
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
            var eventSystem = UnityEngine.EventSystems.EventSystem.current;
            eventSystem.SetSelectedGameObject(restartButton, new BaseEventData(eventSystem));
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

    //event function
    public void ClosePauseMenu()
    {
        TimeController.instance.EndTimer();
        TimeController.instance.timePlaying = TimeSpan.Zero;
        TimeController.instance.timeMenu.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
