using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button StartButton;
    public Button ContinueButton;
    public Button QuitButton;
    
    public void CloseButton()
    {
        StartButton.gameObject.SetActive(false);
        ContinueButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
