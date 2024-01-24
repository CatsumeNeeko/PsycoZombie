using UnityEngine;

public class ZombieNavigation : MonoBehaviour
{
    private bool isChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming you have a method to check for player detection
        if (IsPlayerDetected())
        {
            isChasing = true;
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

    // Method to handle the chase state
    void ChasePlayer()
    {
        // Implement your chase logic here
        // Move towards the player, for example
    }

    // Method to handle the idle state
    void IdleState()
    {
        // Implement your idle or other logic here
        // Perform actions when not chasing the player
    }
}
