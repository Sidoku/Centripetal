using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Serializable]
    public class Sound
    {
        [Header("Clip")] public AudioClip clip;
        [Header("MixerGroup")] public AudioMixerGroup outputGroup;
        [Header("Audio volume")] public float volume;
        [Header("play on Awake")] public bool playOnAwake;
        [Header("loop")] public bool loop;
    }
    
    //在界面里增加上面这些玩意儿
    public List<Sound> sounds;
    private Dictionary<String, AudioSource> audioDictionary;
    private static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioDictionary = new Dictionary<string, AudioSource>();
        }
    }

    private void Start()
    {
        foreach (var sound in sounds)
        {
            //设置名字 把这个gameobject放置在GameManager下面 成为子物体
            var obj = new GameObject(sound.clip.name);
            obj.transform.SetParent(transform);
            AudioSource source = obj.AddComponent<AudioSource>();
            //直接通过面板赋值 然后传值
            source.clip = sound.clip;
            source.outputAudioMixerGroup = sound.outputGroup;
            source.volume = sound.volume;
            source.playOnAwake = sound.playOnAwake;
            source.loop = sound.loop;
            if (sound.playOnAwake)
            {
                source.Play();
            }
            //加入字典
            audioDictionary.Add(sound.clip.name,source);
        }
    }

    //播放某个audio
    public static void PlayAudio(string name, bool isWait = false)
    {
        if (!instance.audioDictionary.ContainsKey(name))
        {
            Debug.LogWarning($"{name}不存在");
            return;
        }
        //播放audio
        if (isWait)
        {
            if (!instance.audioDictionary[name].isPlaying)
            {
                instance.audioDictionary[name].Play();
            }
        }
        else
        {
            instance.audioDictionary[name].Play();
        }
    }

    //stop the audio
    public static void StopAudio(string name)
    {
        if (!instance.audioDictionary.ContainsKey(name))
        {
            Debug.LogWarning($"{name}不存在");
            return;
        }
        instance.audioDictionary[name].Stop();
    }
}
