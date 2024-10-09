using UnityEngine;

public class DamagingObject : MonoBehaviour
{
    public float damageAmount = 10f;  // The amount of damage this object will cause

    // OnTriggerEnter2D is called when another collider enters the trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object we collided with is the player
        if (collision.CompareTag("Player"))
        {
            // Get the PlayerHealthBar component from the player
            PlayerHealthBar playerHealth = collision.GetComponent<PlayerHealthBar>();

            // If the player has a health bar, deal damage
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);  // Deal damage to the player
            }
        }
    }
}
