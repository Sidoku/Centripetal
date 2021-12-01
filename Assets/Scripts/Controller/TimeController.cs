using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{

    public Text time;
    public Text finalTime;
    public GameObject timeMenu;
    public GameObject finalMenu;
    public GameObject finalRestartButton;
    
    private static TimeController _instance;
    public static TimeController instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    private string timePlayingString;

    public TimeSpan timePlaying;
    private bool timerGoing;
    // private bool levelFinished;
    public float elapseTime;
    
    // Start is called before the first frame update
    void Start()
    {
        time.text = "Time:00:00";
        finalTime.text = "Time:00:00";
        timerGoing = false;
        timeMenu.SetActive(false);
    }

    private void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     ShowEndMenu();
        // }
    }
    public void BeginTimer()
    {
        timerGoing = true;
        elapseTime = 0f;
        StartCoroutine(UpdateTime());
        AudioManager.PlayAudio(AudioName.BGM);
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    IEnumerator UpdateTime()
    {
        while (timerGoing)
        {
            elapseTime += Time.deltaTime;//start add time. then change this to timespan, give that value to timeplaying
            timePlaying = TimeSpan.FromSeconds(elapseTime);
            timePlayingString = "Time:" + timePlaying.ToString("mm\\:ss");//minute : second, if want ff, +.'ff'
            time.text = timePlayingString;
            
            yield return null;
        }
    }

    public void ShowEndMenu()
    {
        finalMenu.SetActive(true);
        EndTimer();
        var eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(finalRestartButton, new BaseEventData(eventSystem));
        finalTime.text = timePlayingString;
        timePlaying = TimeSpan.Zero;
        timeMenu.SetActive(false);
    }

}
