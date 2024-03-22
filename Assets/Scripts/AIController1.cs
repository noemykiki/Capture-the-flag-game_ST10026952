using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public string flagTag = "RedFlag"; // Tag of the flag the AI is searching for
    public float moveSpeed = 5f; // Speed of the AI movement
    public float jumpForce = 5f; // Force applied when jumping

    private GameObject targetFlag; // Reference to the target flag GameObject
    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isGrounded; // Flag to track if the AI is grounded

    void Start()
    {
        // Find the GameObject with the specified tag
        targetFlag = GameObject.FindGameObjectWithTag(flagTag);
        if (targetFlag == null)
        {
            Debug.LogError("No GameObject found with tag " + flagTag);
        }

        // Get reference to the Rigidbody component
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody component found on the AI GameObject");
        }

        // Enable Rigidbody to use physics interactions and collisions
        rb.isKinematic = false;
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
            rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);

            // Check if the AI is grounded
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

            // If grounded and jump key is pressed, apply jump force
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
