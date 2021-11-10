using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;
    public int shadowCount;//生成的数量
    public GameObject shadowPrefabs;//获取预制体
    private Queue<GameObject> shadowQueue = new Queue<GameObject>();

    private void Awake()
    {
        instance = this;
        
        //初始化对象池
        AddObjectsToPool();
    }

    private void Start()
    {
        
    }

    private void AddObjectsToPool()
    {
        for (int i = 0; i < shadowCount; i++)
        {
            //生成预制体 然后将其放在该脚本所挂在的物体之下 成为其子物体
            var instantiateShadows = Instantiate(shadowPrefabs, transform, true);
            instantiateShadows.transform.SetParent(transform);
            //生成之后 就进入池子
            ReturnPool(instantiateShadows);
        }
    }

    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);//初始化都是false
        shadowQueue.Enqueue(gameObject);
    }

    public GameObject GetObjectFromPool()
    {
        // Debug.Log("in");
        //考虑数量不够的情况 重新填充
        if (shadowQueue.Count == 0)
        {
            AddObjectsToPool();
        }
        //从对象池里拽出来一个
        var outShadow = shadowQueue.Dequeue();
        outShadow.SetActive(true);
        //这里一旦设置为true 就会执行skill02方法中的OnEnable中的各行参数了
        return outShadow;
    }
    
    // public void CanDash()
    // {
    //     // PlayerController.Instance.skillImages[1].fillAmount = 1;
    //     PlayerController.Instance.isDash = true;
    //     PlayerController.Instance.dashTimeLeft = PlayerController.Instance.dashTime;//剩余冲锋时间要设置成冲锋时间
    //     PlayerController.Instance.lastDashTime = Time.time;//按键CD判断使用
    // }
    //
    // public void SK_02()
    // {
    //     if (!PlayerController.Instance.isDash) return;
    //     if (PlayerController.Instance.dashTimeLeft > 0)//有时间
    //     {
    //         PlayerController.Instance.rb.velocity = new Vector2(PlayerController.Instance.boostForce * PlayerController.Instance.move.x, PlayerController.Instance.rb.velocity.y);
    //         PlayerController.Instance.dashTimeLeft -= Time.deltaTime;
    //         //出现影子
    //         GetObjectFromPool(); 
    //         // if (PlayerController.Instance.verticalInput > 0)
    //         // {
    //         //     PlayerController.Instance.rb.velocity = new Vector2(PlayerController.Instance.rb.velocity.x, PlayerController.Instance.dashSpeedY * PlayerController.Instance.transform.localScale.y);
    //         //     PlayerController.Instance.dashTimeLeft -= Time.deltaTime;
    //         //     //出现影子
    //         //     GetObjectFromPool();
    //         // }
    //     }
    //     if (PlayerController.Instance.dashTime <= 0)
    //     {
    //         PlayerController.Instance.isDash = false;
    //     }
    // }
}
