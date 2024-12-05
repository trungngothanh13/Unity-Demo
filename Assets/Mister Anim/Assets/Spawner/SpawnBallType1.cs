using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpikeBallType1 : SpawnBaseClass
{
    public GameObject objectPrefab;
    private float spawnInterval = 0.2f;
    private float spawnHeight = 20f;
    private float spawnRangeLeft = -28f;
    private float spawnRangeRight = 70f;
    private int maxObjectCount = 10;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    public override void Start()
    {
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }

    public override void SpawnObject()
    {
        float randomX = Random.Range(spawnRangeLeft, spawnRangeRight);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        spawnedObjects.Add(newObject);

        if (spawnedObjects.Count > maxObjectCount)
        {
            Destroy(spawnedObjects[0]);
            spawnedObjects.RemoveAt(0);
        }
    }
}