using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCenter
{
   //singleton
   private static MessageCenter instance;

   public static MessageCenter Instance
   {
      // get => instance;
      get
      {
         if (instance == null)
         {
            instance = new MessageCenter();
         }

         return instance;
      }
   }

   private MessageCenter()
   {
      InitData();
   }

   private Dictionary<string, Action<MessageData>> dictionaryMessage;

   /// <summary>
   /// used in construction function
   /// </summary>
   private void InitData()
   {
      //initialize the dictionary
      dictionaryMessage = new Dictionary<string, Action<MessageData>>();
   }

   /// <summary>
   /// register for a message event
   /// </summary>
   /// <param name="key">message name</param>
   /// <param name="action">message event</param>
   public void RegisterMessage(string key,Action<MessageData> action)
   {
      if (!dictionaryMessage.ContainsKey(key))
      {
         dictionaryMessage.Add(key,null);
      }
      dictionaryMessage[key] += action;
   }

   /// <summary>
   /// move a message event
   /// </summary>
   /// <param name="key">message name</param>
   /// <param name="action">message event</param>
   public void RemoveMessage(string key,Action<MessageData> action)
   {
      if (dictionaryMessage.ContainsKey(key) && dictionaryMessage[key] != null)
      {
         dictionaryMessage[key] -= action;
      }
   }

   /// <summary>
   /// send message
   /// </summary>
   /// <param name="key"></param>
   /// <param name="data"></param>
   public void SendMessage(string key,MessageData data = null)
   {
      if (dictionaryMessage.ContainsKey(key) && dictionaryMessage[key] != null)
      {
         dictionaryMessage[key](data);
      }
   }
   
   /// <summary>
   /// clear all messages
   /// </summary>
   public void Clear()
   {
      dictionaryMessage.Clear();
   }
}
