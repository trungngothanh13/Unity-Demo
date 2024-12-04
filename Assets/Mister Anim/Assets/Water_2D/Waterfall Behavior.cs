using UnityEngine;
using System.Collections;

public class WaterfallEffect : MonoBehaviour
{
    [SerializeField] private float delayTime = 30f; // Time in seconds before the effects apply
    [SerializeField] private Color newColor = Color.black; // Color to change to

    void Start()
    {
        // Start the coroutine to change the color and remove the collider for all children
        StartCoroutine(ApplyEffectToChildrenAfterDelay());
    }

    private IEnumerator ApplyEffectToChildrenAfterDelay()
    {
        // Wait for the delay time
        yield return new WaitForSeconds(delayTime);

        // Iterate through all child objects (including the parent)
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            // Change the color if the child has a SpriteRenderer
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = newColor;
            }
            // Remove the collider if the child has a Collider2D
            Collider2D collider = child.GetComponent<Collider2D>();
            if (collider != null)
            {
                Destroy(collider);
            }
        }
    }
}
