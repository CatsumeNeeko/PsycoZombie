using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerStats.hasToolbox)
            {
                // Player already has a toolbox
                Debug.Log("Player already has a toolbox.");
            }
            else
            {
                // Player obtains toolbox and remove it from the scene
                playerStats.hasToolbox = true;
                Debug.Log("Player obtained the toolbox.");
                Destroy(gameObject); // Remove the toolbox GameObject
            }
        }
    }
}
