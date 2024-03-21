using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform flagHolder;
    private GameObject blueFlag;
    private Vector3 flagOffset = new Vector3(0f, 1f, 0f); // Adjust this offset as needed
    private Collider flagCollider;
    private bool isCarryingFlag = false;

    void Start()
    {
        blueFlag = GameObject.FindGameObjectWithTag("BlueFlag");
        flagCollider = blueFlag.GetComponent<Collider>();
        flagCollider.isTrigger = true; // Initially enable trigger
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == blueFlag && !isCarryingFlag && other.CompareTag("Player"))
        {
            blueFlag.transform.SetParent(flagHolder);
            blueFlag.transform.localPosition = Vector3.zero; // Set local position to (0, 0, 0)
            isCarryingFlag = true;
            flagCollider.isTrigger = false; // Disable trigger when picked up
        }
    }

    void Update()
    {
        if (isCarryingFlag)
        {
            // Update flag position relative to the flag holder
            blueFlag.transform.localPosition = flagOffset; // Adjust position relative to the flag holder
        }

        // Example: Drop the flag when the player presses "F" key
        if (isCarryingFlag && Input.GetKeyDown(KeyCode.F))
        {
            DropFlag();
        }
    }

    void DropFlag()
    {
        Rigidbody flagRigidbody = blueFlag.GetComponent<Rigidbody>();
        flagRigidbody.isKinematic = false;
        flagRigidbody.useGravity = true;
        blueFlag.transform.SetParent(null);
        isCarryingFlag = false;
        StartCoroutine(ToggleTriggerOffForOneSecond());
    }

    IEnumerator ToggleTriggerOffForOneSecond()
    {
        flagCollider.isTrigger = false; // Turn off trigger

        yield return new WaitForSeconds(1f); // Wait for 1 second

        flagCollider.isTrigger = true; // Turn on trigger
    }
   
}
