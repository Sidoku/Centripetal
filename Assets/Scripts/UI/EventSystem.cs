using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour
{
    public GameObject endMenuFirstButton;
    private EventSystem _eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // switch (SceneManager.GetActiveScene().buildIndex)
        // {
        //     case 0:
        //         var eventSystem = UnityEngine.EventSystems.EventSystem.current;
        //         eventSystem.SetSelectedGameObject(endMenuFirstButton, new BaseEventData(eventSystem));
        //         
        //         break;
        // }
    }
}
