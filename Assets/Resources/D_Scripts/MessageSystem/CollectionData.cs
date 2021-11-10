using System;
using UnityEngine;

public class CollectionData
{
    private int appleCount;
    private int bananaCount;
    private int isPlayer;

    public int AppleCount
    {
        get
        {
            return appleCount;
        }
        set
        {
            //当收集之后，就发消息通知UI作出显示
            //消息传递的就是收集之后的那个什么
            appleCount = value;
            MessageCenter.Instance.SendMessage(MessageName.MSG_APPLE_COLLECT, new MessageData(appleCount));
        }
    }

    public int BananaCount
    {
        get => bananaCount;
        set
        {
            bananaCount = value;
            MessageCenter.Instance.SendMessage(MessageName.MSG_BANANA_COLLECT, new MessageData(bananaCount));
        }
    }

    public int IsPlayer
   {
       get => isPlayer;
       set
       {
           isPlayer = value;
           MessageCenter.Instance.SendMessage(MessageName.MSG_BOOL_PLAYER, new MessageData(isPlayer));
       }
   }

    //MessageCenter.Instance.SendMessage(MessageName.MSG_BOOL_PLAYER, new MessageData(isPlayer));
}
