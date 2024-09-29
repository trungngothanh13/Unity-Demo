using UnityEngine;

public class SimpleCharacterMovement : MonoBehaviour
{
    public float speed = 10f;             // Movement speed
    private Rigidbody2D rb;              // Rigidbody2D component for movement
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        // Create a new velocity based on input
        Vector2 movement = new Vector2(horizontal * speed, rb.velocity.y);
        // Apply the movement to the Rigidbody2D
        rb.velocity = movement;

        if (horizontal != 0)
        {
            Vector3 characterScale = transform.localScale;
            characterScale.x = horizontal > 0 ? 1 : -1;  // Flip based on the direction
            transform.localScale = characterScale;
        }

        animator.SetFloat("MovingSpeed", Mathf.Abs(horizontal * speed));
        //Debug.Log("Calculated Speed: " + Mathf.Abs(horizontal * speed));
    }
}