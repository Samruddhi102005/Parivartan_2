using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int coinCount = 0;  // To keep track of collected coins

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is tagged as "Coin"
        if (other.gameObject.CompareTag("coin"))
        {
            // Increment the coin count
            coinCount++;
            Debug.Log("Coins Collected: " + coinCount);

            // Optionally, you can add a sound effect or particle effect here

            // Destroy the coin object
            Destroy(other.gameObject);
        }
    }
}
