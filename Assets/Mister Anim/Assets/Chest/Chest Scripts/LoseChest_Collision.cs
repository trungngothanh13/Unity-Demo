using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseChest_Collision : MonoBehaviour
{
    private Animator animator;
    private bool chestTouched = false;

    public GameObject chillGuyPrefab;
    private bool chillGuySpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !chillGuySpawned)
        {
            chestTouched = true;
            Debug.Log("Collided with: " + collision.gameObject.name);
            animator.SetBool("ChestTouched", chestTouched);

            SpawnChillGuy();
        }

    }
    void SpawnChillGuy()
    {
        if (chillGuyPrefab != null)
        {
            // Define an offset to move the Chill Guy
            Vector3 spawnPosition = transform.position + new Vector3(0, 1.3f, 0);
            // Instantiate the Chill Guy prefab at the new position with the offset
            Instantiate(chillGuyPrefab, spawnPosition, Quaternion.identity);

            chillGuySpawned = true;
        }
        else
        {
            Debug.LogError("Chill Guy Prefab is not assigned!");
        }
    }

}
