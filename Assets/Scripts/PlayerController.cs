using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Transform flagHolder;
    private GameObject blueFlag;
    private Vector3 flagOffset = new Vector3(0f, 1f, 0f); // Adjust this offset as needed
    public GameObject winUI;
    private GameObject bluePodium; 
    
   


    private bool isCarryingFlag = false;

    void Start()
    {
        blueFlag = GameObject.FindGameObjectWithTag("BlueFlag");
        bluePodium = GameObject.FindGameObjectWithTag("BluePodium");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == blueFlag && !isCarryingFlag)
        {
            // Pick up the flag
            //blueFlag.GetComponent<Rigidbody>().isKinematic = true;
            blueFlag.transform.SetParent(flagHolder);
            blueFlag.transform.localPosition = Vector3.zero; // Set local position to (0, 0, 0)
            isCarryingFlag = true;
        }

        if (other.gameObject == bluePodium && isCarryingFlag)
        {
            winUI.gameObject.SetActive(true);
        }
    }
    
    

    void Update()
    {
        if (isCarryingFlag)
        {
            // Update flag position relative to the flag holder
            blueFlag.transform.position = flagHolder.position + flagOffset;
        }

        // Example: Drop the flag when the player presses "F" key
        /*if (isCarryingFlag && Input.GetKeyDown(KeyCode.F))
        {
            DropFlag();
        }*/
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
