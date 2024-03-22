using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro; 

public class AIController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the AI movement
    public string flagTag = "RedFlag"; // Tag of the flag the AI is searching for
    public Transform redFlag; 
    private NavMeshAgent agent;
    private GameObject redFlagObject;
    public Transform enemyFlagHolder;
    public Transform redPodium;
    public GameObject redPodiumObject; 

    private bool isCarryingFlag = false;
    private bool isOnRedPodium = false;
    private Vector3 flagOffset = new Vector3(0f, 1f, 0f); // Adjust this offset as needed
    
  

    private GameObject targetFlag; // Reference to the target flag GameObject

    void Start()
    {
        redFlagObject = GameObject.FindGameObjectWithTag("RedFlag");
        agent = GetComponent<NavMeshAgent>();
        // Find the GameObject with the specified tag
        targetFlag = GameObject.FindGameObjectWithTag(flagTag);
        if (targetFlag == null)
        {
            Debug.LogError("No GameObject found with tag " + flagTag);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == redFlagObject && !isCarryingFlag)
        {
            // Pick up the flag
           
            redFlagObject.transform.SetParent(enemyFlagHolder);
            redFlagObject.transform.localPosition = Vector3.zero; // Set local position to (0, 0, 0)
            isCarryingFlag = true;
        }

        if (other.gameObject == redPodiumObject && isCarryingFlag)
        {
            isOnRedPodium = true;
            Debug.Log("Red wins");
           


        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == redPodium)
        {
            isOnRedPodium = false;
        }
    }

    void Update()
    {
        if (isCarryingFlag)
        { 
            // 3. return to base 
            // Update flag position relative to the flag holder
            redFlag.transform.position = enemyFlagHolder.position + flagOffset;
            agent.destination = redPodium.position;
        }
        if (targetFlag != null && isCarryingFlag == false)
        {
            //2. search flag
            agent.destination = redFlag.position;

        }
    }
}
