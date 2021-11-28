using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    private Animator animator;
    private int tempLevelID;
    private float tempTime;
    void Start()
    {
        animator = GetComponent<Animator>();
        tempLevelID = 0;
        tempTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     LoadNextLevel();
        // }

        if (tempLevelID != SceneManager.GetActiveScene().buildIndex) 
        {
            //if not, it means the level changed
            animator.SetTrigger("End");
            TimeController.instance.elapseTime += tempTime;
            tempTime = 0f;
            tempLevelID = SceneManager.GetActiveScene().buildIndex;
        }
    }

    public void LoadNextLevel()
    {
        tempLevelID = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(ChangeLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator ChangeLevel(int levelIndex)
    {
        animator.SetTrigger("Start");
        TimeController.instance.EndTimer();
        tempTime = TimeController.instance.elapseTime;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex + 1);
    }
}
