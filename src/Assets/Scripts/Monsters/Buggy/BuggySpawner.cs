using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuggySpawner : SpawnableObject
{
    public GameObject buggyPrefab;

    public void Start()
    {
        amountOfObjects = 80; // From SpawnableObject
        PopulateScene(buggyPrefab, this.transform);  // From SpawnableObject
    }
}
