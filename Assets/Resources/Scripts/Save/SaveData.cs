using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class SaveData
{
    public int id;
    public bool status;
    
    public class JsonData
    {
        public List<SaveData> JsonList = new List<SaveData>();
    }
}
[Serializable]
public class BasicData
{
    public int Coin;
}
[Serializable]
public class LevelData
{
    public int ID;
    public bool Status;
    
}

public class Levels
{
    public List<LevelData> LevelSchedule = new List<LevelData>();
}

// public class 
