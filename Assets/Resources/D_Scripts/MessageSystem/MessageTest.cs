using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTest : MonoBehaviour
{
    public int isPlayer;
    private CollectionData userData;

    private void Awake()
    {
        MessageCenter.Instance.RegisterMessage(MessageName.MSG_BOOL_PLAYER,OnPlayerEnterTrigger);
    }

    private void Start()
    {
        userData = new CollectionData();
        userData.IsPlayer = 0;
    }

    private void Update()
    {
        Debug.Log(isPlayer);
    }

    private void OnDestroy()
    {
        MessageCenter.Instance.RemoveMessage(MessageName.MSG_BOOL_PLAYER,OnPlayerEnterTrigger);
    }

    private void OnPlayerEnterTrigger(MessageData data)
    {
        isPlayer = data.valueInt;
    }
    
    public void ChangePlayerStatus()
    {
        userData.IsPlayer = 1;
    }
}
