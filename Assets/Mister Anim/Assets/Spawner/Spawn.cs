using System.Collections.Generic;
using UnityEngine;

public class FaceSpawner : MonoBehaviour
{
    public GameObject facePrefab;     // Reference to the Face prefab
    public float spawnInterval = 1f;  // Time interval between spawns
    public float spawnHeight = 5f;    // Height at which to spawn the object
    public float spawnRangeX = 10f;   // Range for random spawn positions in X
    public int maxFaceCount = 10;      // Maximum number of faces allowed

    private List<GameObject> spawnedFaces = new List<GameObject>();

    private void Start()
    {
        // Start spawning at intervals
        InvokeRepeating("SpawnFace", spawnInterval, spawnInterval);
    }

    private void SpawnFace()
    {
        // Generate a random X position within the specified range
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);

        // Instantiate the facePrefab at the spawnPosition
        GameObject newFace = Instantiate(facePrefab, spawnPosition, Quaternion.identity);

        // Add the new face to the list
        spawnedFaces.Add(newFace);

        // Check if we have exceeded the max count
        if (spawnedFaces.Count > maxFaceCount)
        {
            // Destroy the oldest face and remove it from the list
            Destroy(spawnedFaces[0]);
            spawnedFaces.RemoveAt(0);
        }
    }
}
