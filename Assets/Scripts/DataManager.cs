using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
   public static DataManager Instance { get; private set; }
   
   //public int score;

   public TMP_Text blueScoreText;
   public TMP_Text redScoreText;

   public int blueScore = 0;
   public int redScore = 0;
   public int maxRounds = 5;
   public int currentRound = 1;

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
