using UnityEngine;
using UnityEngine.AI;

public class ZombieNavigation : MonoBehaviour
{
    private bool isChasing = false;
    private Transform playerTransform; // Reference to the player's transform

    // Start is called before the first frame update
    void Start()
    {
        // Assuming you have a method to check for player detection
        if (IsPlayerDetected())
        {
            isChasing = true;
            playerTransform = GetPlayerTransform();
        }
        else
        {
            isChasing = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the zombie is currently chasing, perform chase logic
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            // If not chasing, perform idle or other logic
            IdleState();
        }
    }

    // Method to check for player detection (replace this with your actual detection logic)
    bool IsPlayerDetected()
    {
        // Implement your player detection logic here
        // Return true if player is detected, false otherwise
        return false;
    }

    // Method to get the player's transform (replace this with your actual player reference)
    Transform GetPlayerTransform()
    {
        // Implement how to get the player's transform
        // For example, you could use GameObject.FindWithTag("Player").transform
        return null;
    }

    // Method to handle the chase state
    void ChasePlayer()
    {
        // If player is still in range, continue chasing
        if (IsPlayerDetected())
        {
            // Implement your tracking/following logic here
            // Move towards the player, for example
            MoveTowardsPlayer();
        }
        else
        {
            // If player is not in range, roam around
            Roam();
        }
    }

    // Method to move towards the player
    void MoveTowardsPlayer()
    {
        // Implement your movement logic towards the player
        // For example, you could use Vector3.MoveTowards
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Time.deltaTime * movementSpeed);
    }

    // Method to handle the idle state
    void IdleState()
    {
        // Implement your idle or other logic here
        // Perform actions when not chasing the player
    }

    // Method to roam around
    void Roam()
    {
        // Implement your roaming logic here
        // For example, you could make the zombie move randomly
        Vector3 randomDirection = Random.insideUnitSphere * roamRadius;
        randomDirection.y = 0; // Ensure the zombie stays on the same level
        Vector3 destination = transform.position + randomDirection;
        NavMesh.SamplePosition(destination, out NavMeshHit hit, roamRadius, 1);
        transform.position = hit.position;
    }

    // Variables for roaming
    public float roamRadius = 10f;
    public float movementSpeed = 5f;
}
