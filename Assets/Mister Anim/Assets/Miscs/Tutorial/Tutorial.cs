using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float delay = 5f;  // Time in seconds before the object disappears

    private void Start()
    {
        // Destroy this GameObject after the specified delay
        Destroy(gameObject, delay);
    }
}

public class FaceCamera : MonoBehaviour
{
    private Transform mainCameraTransform;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Make the object face the camera without flipping
        Vector3 directionToFace = mainCameraTransform.position - transform.position;
        directionToFace.y = 0;  // Lock the Y axis to prevent unwanted tilting
        transform.forward = directionToFace.normalized;
    }
}
