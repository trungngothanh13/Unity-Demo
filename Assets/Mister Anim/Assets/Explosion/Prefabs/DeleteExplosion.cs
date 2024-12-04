using UnityEngine;

public class DeleteAfterDelay : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }
}
