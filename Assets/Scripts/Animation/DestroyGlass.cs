using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGlass : MonoBehaviour
{
    

    void Destroy()
    {
        Destroy(gameObject);
    }

    void PlayGlassSound()
    {
        AudioManager.PlayAudio(AudioName.GlassBreak);
    }
}
