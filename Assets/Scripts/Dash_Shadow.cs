using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Shadow : MonoBehaviour
{
    private Transform _player;
    private SpriteRenderer _thisSprite;// 自己的图像
    private SpriteRenderer _playerSprite;//玩家的图像

    private Color _color;

    [Header("Time Controller")] 
    public float activeTime;//显示时间
    public float activeStart;//开始显示的时间
    [Header("不透明度控制")] 
    private float _alpha;
    public float alphaSet;
    public float alphaMultiplier;//不透明度柔和显示
    //要在对象池开始之间就将所有的池子中的active设置为false
    private void OnEnable()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _thisSprite = GetComponent<SpriteRenderer>();
        _playerSprite = _player.GetComponent<SpriteRenderer>();

        _alpha = alphaSet;
        _thisSprite.sprite = _playerSprite.sprite;

        var transform1 = transform;
        transform1.position = _player.transform.position;
        transform1.localScale = _player.localScale;
        transform1.rotation = _player.rotation;

        activeStart = Time.time;//当前时间
    }

    private void Update()
    {
        _alpha *= alphaMultiplier;
        _color = new Color(0.6f, 0.6f, 1, _alpha);//完全显示 对颜色进行调整
        _thisSprite.color = _color;
        
        //超过了分配时间 放回object pool
        if (Time.time >= activeStart + activeTime)
        {
            //object pool method
            ShadowPool.instance.ReturnPool(this.gameObject);
        }
    }
}
