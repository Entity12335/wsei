using UnityEngine;

public class Key : MonoBehaviour
{
    // This method is called when the player collides with the key
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that collided is the player
        if (collision.CompareTag("Player"))
        {
            // Call the method to collect the key
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.CollectKey();
                Destroy(gameObject); // Destroy the key object after collection
            }
        }
    }
}
public class Player : MonoBehaviour
{
    public int keyCount = 0; // Number of keys collected
    public Text keyCountText; // Reference to a UI Text element to display the key count

    // Method to collect a key
    public void CollectKey()
    {
        keyCount++;
        UpdateKeyCountUI();
        Debug.Log("Keys Collected: " + keyCount); // Log the key count to the console
    }

    // Method to update the UI text (if you have a UI to display the key count)
    private void UpdateKeyCountUI()
    {
        if (keyCountText != null)
        {
            keyCountText.text = "Keys: " + keyCount;
        }
    }
}