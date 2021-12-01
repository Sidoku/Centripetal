using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public GameObject starButton;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeToText2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeToText2()
    {
        var eventSystem = UnityEngine.EventSystems.EventSystem.current;
        eventSystem.SetSelectedGameObject(starButton, new BaseEventData(eventSystem));
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeToText1());
        
    }

    IEnumerator ChangeToText1()
    {
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeToText2());
    }

    public void EnterLevels()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        TimeController.instance.timeMenu.SetActive(true);
        // TimeController.instance.BeginTimer();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
