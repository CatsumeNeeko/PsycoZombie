using System.Collections;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{
    private bool isPlayerNear = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is near and press the "E" key
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            // Call a method to start the item removal process
            StartCoroutine(RemoveItemProcess());
        }
    }

    // Coroutine to handle the item removal process
    private IEnumerator RemoveItemProcess()
    {
        float elapsedTime = 0f;
        float requiredPressTime = 3f;

        // Continue the loop until the required time is reached
        while (elapsedTime < requiredPressTime)
        {
            // Check if the "E" key is still held down
            if (!Input.GetKey(KeyCode.E))
            {
                yield break; // Exit the coroutine if the key is released
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Remove the game object after the required press time
        Destroy(gameObject);
    }
}
