using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnableObject : MonoBehaviour
{
    protected float yMinBound = -5.96f;
    protected float yMaxBound = -488.21f;
    protected float xMaxBound = 5.86f;
    protected float xMinBound = -6.48f;

    protected int amountOfObjects;

    protected void PopulateScene(GameObject prefab, Transform parentTransform) // Spawn go's on loop, if they collide, find new spawn point
    {
        for (int i = 0; i < amountOfObjects; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMinBound, xMaxBound), Random.Range(yMinBound, yMaxBound));
            Instantiate(prefab, position, Quaternion.identity, parentTransform);
        }
    }

    protected void PopulateIndividual(GameObject prefab, Transform parentTransform) // Spawns go's without loop (used to spawn 2 random types of blocks)
    {
        Vector2 position = new Vector2(Random.Range(xMinBound, xMaxBound), Random.Range(yMinBound, yMaxBound));
        Instantiate(prefab, position, Quaternion.identity, parentTransform);
    }

    //protected void SpawnOnBlocks(GameObject prefab, Transform parentTransform, int amountOfBlocks)
    //{
    //    List<Vector2> blockList = new List<Vector2>();
    //    for(int i = 0; i < amountOfBlocks; i++)
    //    {
    //        blockList.Add(GameObject.FindGameObjectsWithTag("Ground")[i].transform.position);
    //        Instantiate(prefab, blockList[i], Quaternion.identity, parentTransform);
            
    //    }
    //}
}
