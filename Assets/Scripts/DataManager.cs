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
   public GameObject endMenu;
   public GameObject blueWin;
   public GameObject redWin;

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

   public void Update()
   {
      if (blueScore == 5 || redScore == 5)
      {
         Debug.Log("game is over");
         endMenu.gameObject.SetActive(true);
         Time.timeScale = 0f;

         if (blueScore >= maxRounds)
         {
            
            Debug.Log("blue wins");
            blueWin.gameObject.SetActive(true);
         }
         else if (redScore >= maxRounds)
         {
           
            Debug.Log("red wins");
            redWin.gameObject.SetActive(true);
         }
      }
   }

  
}
