using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public Text time;
    public Text finalTime;
    public GameObject finalMenu;
    private string timePlayingString;

    private TimeSpan timePlaying;
    private bool timerGoing;
    // private bool levelFinished;
    public float elapseTime;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        time.text = "Time:00:00";
        finalTime.text = "Time:00:00";
        timerGoing = false;
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

    private void ShowEndMenu()
    {
        finalMenu.SetActive(true);
        EndTimer();
        finalTime.text = timePlayingString;
    }

}
