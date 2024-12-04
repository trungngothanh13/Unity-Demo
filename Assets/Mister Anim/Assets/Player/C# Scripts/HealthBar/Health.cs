using UnityEngine;
using System.Collections;
using Unity.VisualScripting; // Ensure this is included for IEnumerator
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float iframeDuration = 0.7f;
    public float currentHealth { get; private set; }
    private Animator animator;
    private bool isHit = false;
    private bool isDead = false;
    private bool isInvincible = false;

    private SimpleCharacterMovement characterMovement;

    void Start()
    {
        currentHealth = startingHealth;
        animator = GetComponentInChildren<Animator>();
        characterMovement = GetComponent<SimpleCharacterMovement>(); // Get reference to movement script
    }


    void TakeDamage(float damage)
    {
        if (isInvincible || isDead) return; // Ignore damage during invincibility or if dead
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            isHit = true;
            animator.SetBool("IsHit", isHit);
            StartCoroutine(EnableIframes()); // Start the invincibility coroutine
        }
        else
        {
            if (!isDead && enabled)
            {
                isDead = true;
                animator.SetBool("IsDead", isDead);
                if (characterMovement != null)
                    characterMovement.enabled = false;
                Invoke("YouLose", 3f);
            }
        }
    }

    IEnumerator EnableIframes()
    {
        isInvincible = true;
        if (characterMovement != null)
            characterMovement.enabled = false;
        yield return new WaitForSeconds(iframeDuration); // Wait for the iframe duration

        if (characterMovement != null)
            characterMovement.enabled = true;
        isHit = false;
        animator.SetBool("IsHit", isHit);
        yield return new WaitForSeconds(iframeDuration);

        isInvincible = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && enabled)
            TakeDamage(1f);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Explosion") && enabled)
            TakeDamage(currentHealth);
    }

    void YouLose()
    {
        SceneManager.LoadScene("You Lose");
    }

}
