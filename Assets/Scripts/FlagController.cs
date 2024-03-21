using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    private Collider flagCollider;
    private bool playerInsideTrigger;

    void Start()
    {
        flagCollider = GetComponent<Collider>();
        flagCollider.isTrigger = false; // Initially disable trigger
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
            flagCollider.isTrigger = true; // Enable trigger for player
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            CheckGroundCollision(); // Check if flag is still above ground
        }
    }

    void CheckGroundCollision()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                flagCollider.isTrigger = false; // Disable trigger for ground
            }
        }
    }

    void FixedUpdate()
    {
        if (playerInsideTrigger)
        {
            CheckGroundCollision(); // Check ground collision periodically
        }
    }
}
