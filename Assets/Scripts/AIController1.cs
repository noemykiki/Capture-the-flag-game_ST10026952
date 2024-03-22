using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public string flagTag = "RedFlag"; // Tag of the flag the AI is searching for

    private GameObject targetFlag; // Reference to the target flag GameObject
    private UnityEngine.AI.NavMeshAgent agent; // Reference to the NavMeshAgent component

    void Start()
    {
        // Find the GameObject with the specified tag
        targetFlag = GameObject.FindGameObjectWithTag(flagTag);
        if (targetFlag == null)
        {
            Debug.LogError("No GameObject found with tag " + flagTag);
        }

        // Get reference to the NavMeshAgent component
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("No NavMeshAgent component found on the AI GameObject");
        }
    }

    void Update()
    {
        if (targetFlag != null)
        {
            // Set the destination of the NavMeshAgent to the target flag's position
            agent.SetDestination(targetFlag.transform.position);
        }
    }
}
