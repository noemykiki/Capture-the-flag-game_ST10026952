using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the AI movement
    public string flagTag = "RedFlag"; // Tag of the flag the AI is searching for
    public Transform redFlag; 
    private NavMeshAgent agent;

    private GameObject targetFlag; // Reference to the target flag GameObject

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
            agent.destination = redFlag.position;

        }
    }
}
