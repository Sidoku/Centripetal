using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 消息传递的参数
/// </summary>
public class MessageData
{
    //定义传输的数据类型
    public int valueInt;

    public MessageData(int value)
    {
        valueInt = value;
    }
}
