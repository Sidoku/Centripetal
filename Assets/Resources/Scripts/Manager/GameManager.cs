using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }//可读，但只能在内部改写
    public bool gameOver;
    //public int levelID;//用于退出面板的判断 获得当前玩到哪一关的状态+通关则设置json中的key value 为 true
    //public List<Enemy> enemy = new List<Enemy>();
    public List<GameObject> coins = new List<GameObject>();
    //public bool enemyAllDead;
    //public int TryOutID;
    //private readonly int[] _passCondition = {1,5,8,12,15,0,1,5,8,12,15};
    //private Door _exitDoor;
    //UIFramework
    // public SceneSystem SceneSystem { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //初始化D
            // SceneSystem = new SceneSystem();
            DontDestroyOnLoad(gameObject);
            // GetComponent<Model>();
            // Debug.Log(Model.);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //在这里管理新场景的开始了！！
        // SceneSystem.SetScene(new StartScene());
    }

    // private void OnEnable()
    // {
    //     EventManager.Instance.RegisterListener("NextGameLevel",NextGameLevel);
    // }
    //
    // private void OnDestroy()
    // {
    //     EventManager.Instance.RemoveListener("NextGameLevel",NextGameLevel);
    // }

    private void Update()
    {
        gameOver = PlayerController.Instance.isDead;
    }
    
    
   
    /**
     * 这里使用的都是观察者模式
     */
    // public void IsEnemy(Enemy enemy)
    // {
    //     this.enemy.Add(enemy);
    // }
    
    public void IsPlayer(PlayerController controller)
    {
        PlayerController.Instance = controller;
    }
    

}
