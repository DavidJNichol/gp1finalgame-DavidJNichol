using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpSpawner : SpawnableObject
{
    public GameObject impPrefab;

    public BlockSpawner blockSpawner;

    public void Start()
    {
        amountOfObjects = 120; // From SpawnableObject
        SpawnOnBlocks(impPrefab, this.transform, blockSpawner.amountOfBlocks);  // From SpawnableObject
    }
}
