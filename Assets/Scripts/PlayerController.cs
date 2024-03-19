using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform flagHolder;
    private GameObject blueFlag;
    private Vector3 flagOffset = new Vector3(0f, 1f, 0f); // Adjust this offset as needed
   


    private bool isCarryingFlag = false;

    void Start()
    {
        blueFlag = GameObject.FindGameObjectWithTag("BlueFlag");
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
    }

    void Update()
    {
        if (isCarryingFlag)
        {
            // Update flag position relative to the flag holder
            blueFlag.transform.position = flagHolder.position + flagOffset;
        }

        // Example: Drop the flag when the player presses "F" key
        if (isCarryingFlag && Input.GetKeyDown(KeyCode.F))
        {
            DropFlag();
        }
    }

   
    // ReSharper disable Unity.PerformanceAnalysis
    void DropFlag()
    {
        blueFlag.GetComponent<Rigidbody>().isKinematic = false; 
        blueFlag.GetComponent<Rigidbody>().useGravity = true; 
        blueFlag.transform.SetParent(null);
        isCarryingFlag = false;
        
        
    }
    
   
}
