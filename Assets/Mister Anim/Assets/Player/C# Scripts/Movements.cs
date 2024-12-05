using UnityEngine;

public class SimpleCharacterMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public float shortJumpMultiplier = 0.5f;
    public Transform groundCheck;         // Point to check if the character is on the ground
    public LayerMask groundLayer;         // Layer representing the ground
    private Rigidbody2D rb;               // Rigidbody2D component for movement
    private Animator animator;
    private bool isGrounded;
    private bool isJumping;
    //private bool isImmobilized;           // Track if the character is immobilized

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);  // Apply the movement to the Rigidbody2D
        rb.velocity = movement; 

        if (horizontal != 0)
        {
            Vector3 characterScale = transform.localScale;
            characterScale.x = horizontal > 0 ? 1 : -1;  // Flip based on the direction
            transform.localScale = characterScale;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer); // Check if the character is on the ground using groundCheck

        if (Input.GetButtonDown("Jump") && isGrounded) // Jump when the player presses the jump button and is on the ground
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
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