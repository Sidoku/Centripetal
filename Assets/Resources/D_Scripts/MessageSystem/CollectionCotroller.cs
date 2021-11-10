using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionCotroller : MonoBehaviour
{
    public Text appleText;
    public Text bananaText;
    public Text coinText;
    private CollectionData userData;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("CoinNumber"))
        {
            PlayerPrefs.SetInt("CoinNumber",0);
        }
        MessageCenter.Instance.RegisterMessage(MessageName.MSG_APPLE_COLLECT,OnAppleCountChange);
        MessageCenter.Instance.RegisterMessage(MessageName.MSG_BANANA_COLLECT,OnBananaCountChange);
    }

    void Start()
    {
        userData = new CollectionData();
        userData.AppleCount = 0;
        userData.BananaCount = 0;
        coinText.text = PlayerPrefs.GetInt("CoinNumber").ToString();
    }

    private void OnDestroy()
    {
        MessageCenter.Instance.RemoveMessage(MessageName.MSG_APPLE_COLLECT,OnAppleCountChange);
        MessageCenter.Instance.RemoveMessage(MessageName.MSG_BANANA_COLLECT,OnBananaCountChange);
    }

    /// <summary>
    /// 显示apple数量的事件
    /// </summary>
    /// <param name="data"></param>
    private void OnAppleCountChange(MessageData data)
    {
        appleText.text = $"{data.valueInt}";//==string.format("{0},data.valueInt")
    }
    
    private void OnBananaCountChange(MessageData data)
    {
        bananaText.text = $"{data.valueInt}";//==string.format("{0},data.valueInt")
    }

    public void AddAppleCount()
    {
        userData.AppleCount += 1;
    }

    public void AddBananaCount()
    {
        userData.BananaCount += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
