using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpSpawner : SpawnableObject
{
    public GameObject impPrefab;

    public BlockSpawner blockSpawner;

    public void Start()
    {
        amountOfObjects = 80; // From SpawnableObject
        PopulateScene(impPrefab, this.transform);  // From SpawnableObject
    }
}
