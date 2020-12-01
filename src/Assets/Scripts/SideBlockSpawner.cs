using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBlockSpawner : MonoBehaviour
{
    public GameObject sideBlock;

    private int amountOfBlocks;

    private Vector3 position;

    private void Awake()
    {
        amountOfBlocks = 500;
        position = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnSideBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSideBlocks()
    {
        for(int i = 0; i <amountOfBlocks; i++)
        {
            GameObject.Instantiate(sideBlock, position, Quaternion.identity, this.transform);
            position.y--;
        }
    }
}
