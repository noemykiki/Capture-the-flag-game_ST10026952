using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the AI movement
    public string flagTag = "RedFlag"; // Tag of the flag the AI is searching for

    private GameObject targetFlag; // Reference to the target flag GameObject

    void Start()
    {
        // Find the GameObject with the specified tag
        targetFlag = GameObject.FindGameObjectWithTag(flagTag);
        if (targetFlag == null)
        {
            Debug.LogError("No GameObject found with tag " + flagTag);
        }
    }

    void Update()
    {
        if (targetFlag != null)
        {
            // Calculate the direction to the target flag
            Vector3 direction = targetFlag.transform.position - transform.position;
            direction.y = 0; // Ensure the AI moves only along the XZ plane

            // Normalize the direction to maintain constant speed
            direction.Normalize();

            // Move the AI towards the target flag
            transform.Translate(direction * (moveSpeed * Time.deltaTime));
        }
    }
}
