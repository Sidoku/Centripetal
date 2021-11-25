using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusScriptLevel_01 : MonoBehaviour
{
    [SerializeField] private float busMoveSpeed = -0.01f;

    public GameObject destoryBus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(busMoveSpeed, 0, 0);
    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 10 seconds after loading the object
        Destroy(destoryBus, 10);

    }
}
