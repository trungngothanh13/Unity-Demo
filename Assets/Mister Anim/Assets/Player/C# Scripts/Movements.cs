using UnityEngine;

public class SimpleCharacterMovement : MonoBehaviour
{
    public float speed = 10f;             // Movement speed
    public float jumpForce = 10f;          // Force applied for jumping
    public float shortJumpMultiplier = 0.5f;  // Multiplier for a short jump
    public Transform groundCheck;         // Point to check if the character is on the ground
    public LayerMask groundLayer;         // Layer representing the ground
    private Rigidbody2D rb;               // Rigidbody2D component for movement
    private Animator animator;
    private bool isGrounded;
    private bool isJumping;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);
        // Apply the movement to the Rigidbody2D
        rb.velocity = movement;

        if (horizontal != 0)
        {
            Vector3 characterScale = transform.localScale;
            characterScale.x = horizontal > 0 ? 1 : -1;  // Flip based on the direction
            transform.localScale = characterScale;
        }

        // Check if the character is on the ground using groundCheck
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Jump when the player presses the jump button and is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  // Apply vertical jump force
            isJumping = true;  // Mark that the character is jumping
        }

        // If the jump button is released before reaching the peak of the jump, reduce the jump height
        if (Input.GetButtonUp("Jump") && isJumping)
        {
            if (rb.velocity.y > 0)  // Only modify the velocity if the character is still moving upwards
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * shortJumpMultiplier);  // Reduce upward velocity
            }
            isJumping = false;  // Reset the jumping state
        }


        animator.SetFloat("MovingSpeed", Mathf.Abs(horizontal * speed));
        animator.SetBool("IsGrounded", isGrounded);
    }


}