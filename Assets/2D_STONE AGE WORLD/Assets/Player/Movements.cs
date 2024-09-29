using UnityEngine;

public class SimpleCharacterMovement : MonoBehaviour
{
    public float speed = 5f;             // Movement speed
    private Rigidbody2D rb;              // Rigidbody2D component for movement
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
    }

    void Update()
    {
        // Get the horizontal input (A/D keys or left/right arrow keys)
        float horizontal = Input.GetAxis("Horizontal");

        // Create a new velocity based on input
        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);

        // Apply the movement to the Rigidbody2D
        rb.velocity = movement;

        // Flip the character sprite based on the movement direction
        if (horizontal != 0)
        {
            Vector3 characterScale = transform.localScale;
            characterScale.x = horizontal > 0 ? 1 : -1;  // Flip based on the direction
            transform.localScale = characterScale;
        }
    }
}