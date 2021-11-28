using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public Text time;

    private TimeSpan timePlaying;
    private bool timerGoing;
    public float elapseTime;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        time.text = "Time:00:00";
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapseTime = 0f;
        StartCoroutine(UpdateTime());
        
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
            string timePlayingString = "Time:" + timePlaying.ToString("mm\\:ss");//minute : second, if want ff, +.'ff'
            time.text = timePlayingString;
            
            yield return null;
        }
    }

}
