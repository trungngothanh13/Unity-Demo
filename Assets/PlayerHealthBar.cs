using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microlight.MicroBar;  // Include MicroBar namespace

public class PlayerHealthBar : MonoBehaviour
{
    public MicroBar healthBar;  // Reference to the MicroBar health bar
    public float maxHealth = 100f;  // Max health of the player
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize health bar with maximum health
        currentHealth = maxHealth;
        healthBar.Initialize(maxHealth);  // Use the Initialize method from the MicroBar base script
    }

    // Method to take damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health doesn't go below 0
        healthBar.UpdateBar(currentHealth, UpdateAnim.Damage);  // Update health bar with damage animation

        if (currentHealth <= 0)
        {
            Die();  // Handle player death when health reaches 0
        }
    }

    // Method to heal
    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health doesn't exceed max health
        healthBar.UpdateBar(currentHealth, UpdateAnim.Heal);  // Update health bar with heal animation
    }

    // Handle player death
    void Die()
    {
        Debug.Log("Player has died!");
        // You can add additional logic here for when the player dies (e.g., respawn or game over)
    }
}
