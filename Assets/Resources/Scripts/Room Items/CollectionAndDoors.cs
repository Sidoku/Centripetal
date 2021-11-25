using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionAndDoors : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<string, GameObject> c_Dictionary = new Dictionary<string, GameObject>();
    public GameObject[] items;
    public GameObject[] doors;

    public List<GameObject> itemList;
    public List<GameObject> doorList;

    private static CollectionAndDoors _instance;
    public static CollectionAndDoors Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CollectionAndDoors>();
            }
    
            return _instance;
        }
    }
    
    
    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        foreach (var t in items)
        {
            itemList.Add(t);
        }
        
        foreach (var t in doors)
        {
            doorList.Add(t);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //判断，物体消失
        if (itemList.Count == 0)
        {
            foreach (var t in doorList)
            {
                Destroy(t);
            }
            Destroy(gameObject,1.5f);
        }
    }
}
