using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public GameObject endMenu;
    public GameObject endMenuFirstButton;
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        endMenu.gameObject.SetActive(false);
        TimeController.instance.elapseTime = 0f;
        TimeController.instance.time.text = "Time:00:00";
        TimeController.instance.BeginTimer();
        TimeController.instance.timeMenu.SetActive(true);
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene(0);
        endMenu.gameObject.SetActive(false);
        // var eventSystem = UnityEngine.EventSystems.EventSystem.current;
        // eventSystem.SetSelectedGameObject(endMenuFirstButton, new BaseEventData(eventSystem));
    }

    // private void SearchStartButton()
    // {
    //     
    // }
}
