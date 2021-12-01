using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public GameObject endMenu;
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        endMenu.gameObject.SetActive(false);
        TimeController.instance.elapseTime = 0f;
        TimeController.instance.time.text = "Time:00:00";
        TimeController.instance.BeginTimer();
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene(0);
        endMenu.gameObject.SetActive(false);
    }
}
