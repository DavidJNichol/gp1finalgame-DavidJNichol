using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : SpawnableObject
{
    public GameObject blockPrefab;

    public int amountOfBlocks;

    //public List<Vector2> locationList;

    void Start()
    {
        amountOfObjects = 120;
        amountOfBlocks = amountOfObjects;
        //locationList = new List<Vector2>();
        PopulateScene(blockPrefab, this.transform);
        //PopulateList();
    }

    //private void PopulateList()
    //{
    //    for(int i = 0; i < amountOfObjects; i++)
    //    {
    //        locationList.Add(positionList[i]);
    //    }
    //}
}
