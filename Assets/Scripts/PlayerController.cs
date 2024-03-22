using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Transform flagHolder;
    public GameObject winUI;
    
    private bool isCarryingFlag = false;
    private bool isCarryingEnemyFlag = false;
    private bool isOnBluePodium = false;
    private GameObject blueFlag;
    private GameObject redFlag;
    private GameObject bluePodium;
    private Vector3 flagOffset = new Vector3(-2f, 0f, 0f); // Adjust this offset as needed
  
   

    void Start()
    {
        blueFlag = GameObject.FindGameObjectWithTag("BlueFlag");
        redFlag = GameObject.FindGameObjectWithTag("RedFlag");
        bluePodium = GameObject.FindGameObjectWithTag("BluePodium");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == blueFlag && !isCarryingFlag && !isCarryingEnemyFlag)
        {
            // Pick up the flag
            //blueFlag.GetComponent<Rigidbody>().isKinematic = true;
            blueFlag.transform.SetParent(flagHolder);
            blueFlag.transform.localPosition = Vector3.zero; // Set local position to (0, 0, 0)
            isCarryingFlag = true;
        }

        if (other.gameObject == redFlag && !isCarryingFlag && !isCarryingEnemyFlag)
        {
            //Pick up enemy flag
            redFlag.transform.SetParent(flagHolder);
            redFlag.transform.localPosition = Vector3.zero;
            isCarryingEnemyFlag = true;
        }

        if (other.gameObject == bluePodium && isCarryingFlag)
        {
            winUI.gameObject.SetActive(true);
            isOnBluePodium = true;
            
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == bluePodium)
        {
            isOnBluePodium = false;
        }
    }


    void Update()
    {
        if (isCarryingFlag)
        {
            // Update flag position relative to the flag holder
            blueFlag.transform.position = flagHolder.position;
        }

        if (isCarryingEnemyFlag)
        {
            redFlag.transform.position = flagHolder.position + flagOffset;
        }

        // Example: Drop the flag when the player presses "F" key
        /*if (isCarryingFlag && Input.GetKeyDown(KeyCode.F))
        {
            DropFlag();
        }*/

        if (isOnBluePodium == true)
        {
          /**  if (Input.GetKeyDown(KeyCode.R))
            {
                // Restart the scene
                SceneManager.LoadScene("SampleScene");
            } **/
        }
    }

   
    // ReSharper disable Unity.PerformanceAnalysis
    void DropFlag()
    {
        blueFlag.GetComponent<Rigidbody>().isKinematic = false; 
        blueFlag.GetComponent<Rigidbody>().useGravity = true; 
        blueFlag.transform.SetParent(null);
        isCarryingFlag = false;
        StartCoroutine(ToggleTriggerOffForOneSecond());
        
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator ToggleTriggerOffForOneSecond()
    {
        blueFlag.GetComponent<Collider>().isTrigger = false; // Turn off trigger 

        yield return new WaitForSeconds(1f); // Wait for 1 second
        
        blueFlag.GetComponent<Collider>().isTrigger = true; //turn on trigger 

       
    }
   
}
