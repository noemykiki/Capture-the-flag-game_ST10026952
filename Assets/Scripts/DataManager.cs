using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   public static DataManager Instance { get; private set; }
   
   //public int score;

   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
         DontDestroyOnLoad(this.GameObject());
      }
      else
      {
         Destroy(this.GameObject());
      }
   }
}
