using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlockSpawner : SpawnableObject
{
    public GameObject blockPrefab;

    public GameObject blockGroupPrefab;

    void Start()
    {
        amountOfObjects = 100;

        SpawnRandomBlockType();
    }

    public void SpawnRandomBlockType()
    {
        for(int i = 0; i < amountOfObjects; i++)
        {
            float randNumber = Random.Range(0, 5); // 0 and 5 are inclusive

            if(randNumber % 2 == 0) // If number is even, spawn block. If odd, spawn gem block. 50% chance
            {
                PopulateIndividual(blockPrefab, this.transform);
            }
            else
            {
                PopulateIndividual(blockGroupPrefab, this.transform);
            }
        }

    }
}
