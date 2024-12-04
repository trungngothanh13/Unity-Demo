using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseChest_Collision : MonoBehaviour
{
    private Animator animator;
    private bool chestTouched = false;

    public GameObject chillGuyPrefab;
    public GameObject explosionPrefab;
    private bool chillGuySpawned = false;
    //private bool explosionSpawned = false;

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
            Invoke("SpawnExplosion", 3f);
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
    }
    void SpawnExplosion()
    {
        if (chillGuyPrefab != null)
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Instantiate the Explosion prefab at chest
    }
}
