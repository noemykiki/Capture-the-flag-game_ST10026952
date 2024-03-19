using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public Transform flagHolder;
        private GameObject blueFlag;
        private bool isCarryingFlag = false;
        private Rigidbody flagRigidbody; // Reference to flag's Rigidbody component
    
        void Start()
        {
            blueFlag = GameObject.FindGameObjectWithTag("BlueFlag");
            flagRigidbody = blueFlag.GetComponent<Rigidbody>();
        }
    
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BlueFlag") && !isCarryingFlag)
            {
                Debug.Log("Collided with the flag");
                
                // Pick up the flag
                flagRigidbody.isKinematic = true;
                flagRigidbody.useGravity = false; // Disable gravity
                blueFlag.transform.SetParent(flagHolder);
                blueFlag.transform.localPosition = Vector3.zero; // Set local position to (0, 0, 0)
                isCarryingFlag = true;
    
                Debug.Log("Flag picked up");
            }
        }
    
        void Update()
        {
            Debug.Log("Update method called");
            if (isCarryingFlag)
            {
                // Update flag position to follow the player's flag holder
                blueFlag.transform.position = flagHolder.position;
            }
    
            // Example: Drop the flag when the player presses "F" key
            if (isCarryingFlag && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Dropping flag");
                DropFlag();
            }
        }
    
        void DropFlag()
        {
            flagRigidbody.isKinematic = false; // Allow physics simulation
            flagRigidbody.useGravity = true; // Enable gravity
            blueFlag.transform.SetParent(null); // Remove parent relationship
            isCarryingFlag = false;
        }
}
