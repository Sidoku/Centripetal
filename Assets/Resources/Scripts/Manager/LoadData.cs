using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadData : MonoBehaviour
{
    public static LoadData instance;
    private SaveData.JsonData Data;
    private BasicData basicData;
    public Levels levelData;
    public string path1;
    public string path2;
    public string path3;
    public int coinNumber;
    public static Dictionary<int, bool> SK = new Dictionary<int, bool>
    {
        {0,false},{1,false},{2,false},{3,false}
    };
    public static Dictionary<int, bool> LevelStatus = new Dictionary<int, bool>
    {
        {1,false},{2,false},{3,false},{4,false},{5,false},{6,false}
    };
    private void Awake()
    {
        instance = this;
        path1 = Application.streamingAssetsPath + "/ShoppingData.json";//不这么写就没法打包json配置文件
        path2 = Application.streamingAssetsPath + "/BasicData.json";
        path3 = Application.streamingAssetsPath + "/LevelData.json";
        LoadJsonData();
        LoadBasicData();
        LoadLevelData();
        coinNumber = LoadCoinNumber();
    }

    private void LoadJsonData()
    {
        var path = Application.dataPath + "/StreamingAssets" + "/ShoppingData.json";
        var streamReader = new StreamReader(path1);
        //json ---> object
        var jsonString = streamReader.ReadToEnd();
        streamReader.Close();
        // obj --> json
        Data = JsonUtility.FromJson<SaveData.JsonData>(jsonString);
        for (int i = 0; i < Data.JsonList.Count; i++)
        {
            SK[i] = Data.JsonList[i].status;//游戏开始的时候载入购买的状态
        }
    }

    private void LoadBasicData()//金币数据读取，并且赋值给对应的字典
    {
        var path = Application.dataPath + "/StreamingAssets" + "/BasicData.json";
        // string path = Application.dataPath + "/Resources/Json/BasicData.json";
        StreamReader streamReader = new StreamReader(path2);
        //json ---> object
        string jsonString = streamReader.ReadToEnd();
        streamReader.Close();
        // obj --> json
        basicData = JsonUtility.FromJson<BasicData>(jsonString);
    }

    private void LoadLevelData()//关卡数据读取，并且赋值给对应的字典
    {
        var path = Application.dataPath + "/StreamingAssets" + "/LevelData.json";   
        // var path = Application.dataPath + "/Resources/Json/LevelData.json";
        StreamReader streamReader = new StreamReader(path3);
        //json ---> object
        var jsonString = streamReader.ReadToEnd();
        streamReader.Close();
        // obj --> json
        levelData = JsonUtility.FromJson<Levels>(jsonString);//拿到level的key value
        for (int i = 0; i < levelData.LevelSchedule.Count; i++)
        {
            LevelStatus[i] = levelData.LevelSchedule[i].Status;//将json中的key value塞进字典里
        }
    }

    private SaveData.JsonData CreateSaveObject()//用于保存购买的状态
    {
        for (int i = 0; i < Data.JsonList.Count; i++)
        {
            Data.JsonList[i].status = SK[i];
        }
        return Data;
    }

    private Levels CreateLevelDataObject()
    {
        for (int i = 0; i < levelData.LevelSchedule.Count; i++)
        {
            levelData.LevelSchedule[i].Status = LevelStatus[i];
        }
        return levelData;
    }
    public void SaveJsonData()//技能购买记忆存储
    {
        var jsonString = JsonUtility.ToJson(CreateSaveObject());
        var path = Application.dataPath + "/StreamingAssets" + "/ShoppingData.json";
        // var path = Application.dataPath + "/Resources/Json/ShoppingData.json";
        StreamWriter streamWriter = new StreamWriter(path1);
        streamWriter.Write(jsonString);
        streamWriter.Close();
    }

    private BasicData CreateBasicObject()
    {
        basicData.Coin = coinNumber;//TODO
        // basicData.diamond = DiamondUI.
        return basicData;
    }

    public void SaveBasicData()//金币保存
    {
        var jsonString = JsonUtility.ToJson(CreateBasicObject());
        // var path = Application.dataPath + "/Resources/Json/BasicData.json";
        var path = Application.dataPath + "/StreamingAssets" + "/BasicData.json";
        StreamWriter streamWriter = new StreamWriter(path2);
        streamWriter.Write(jsonString);
        streamWriter.Close();
    }

    public void SaveLevelData()//关卡进度保存
    {
        string jsonString = JsonUtility.ToJson(CreateLevelDataObject());
        // string path = Application.dataPath + "/Resources/Json/LevelData.json";
        var path = Application.dataPath + "/StreamingAssets" + "/LevelData.json";
        StreamWriter streamWriter = new StreamWriter(path3);
        streamWriter.Write(jsonString);
        streamWriter.Close();
    }
    
    private int LoadCoinNumber()
    {
        return basicData.Coin;
    }

        
}
