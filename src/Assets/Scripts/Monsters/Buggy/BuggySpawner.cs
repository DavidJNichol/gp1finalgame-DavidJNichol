using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuggySpawner : SpawnableObject
{
    public GameObject buggyPrefab;

    public void Start()
    {
        amountOfObjects = 120; // From SpawnableObject
        PopulateScene(buggyPrefab, this.transform);  // From SpawnableObject
    }
}
