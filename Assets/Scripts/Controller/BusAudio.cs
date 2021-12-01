using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusAudio : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         AudioManager.PlayAudio(AudioName.CarHone_1);
      }
   }
}
