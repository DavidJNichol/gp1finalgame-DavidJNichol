using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnableObject : MonoBehaviour
{
    protected float yMinBound = -5.96f;
    protected float yMaxBound = -488.21f;
    protected float xMaxBound = 5.658f;
    protected float xMinBound = -6.27f;

    protected int amountOfObjects;

    //protected List<Vector2> positionList;

    //protected void FindNewSpawnPoint(Transform transform)
    //{
    //    transform.position = new Vector2(Random.Range(xMinBound, xMaxBound), Random.Range(yMinBound, yMaxBound));
    //}

    protected void PopulateScene(GameObject prefab, Transform parentTransform)
    {
        for (int i = 0; i < amountOfObjects; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMinBound, xMaxBound), Random.Range(yMinBound, yMaxBound));
            Instantiate(prefab, position, Quaternion.identity, parentTransform);
        }
    }

    protected void SpawnOnBlocks(GameObject prefab, Transform parentTransform, int amountOfBlocks)
    {
        List<Vector2> blockList = new List<Vector2>();
        for(int i = 0; i < amountOfBlocks; i++)
        {
            blockList.Add(GameObject.FindGameObjectsWithTag("Ground")[i].transform.position);
            Instantiate(prefab, blockList[i], Quaternion.identity, parentTransform);
            
        }
    }


    //protected void SpawnOnBlocks(GameObject prefab, Transform parentTransform, List<Vector2> positionList)
    //{
    //    for(int i = 0; i < amountOfObjects; i++)
    //    {
    //        Instantiate(prefab, positionList[i], Quaternion.identity, parentTransform);
    //    }
    //}
}
