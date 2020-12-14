using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightBlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    private List<GameObject> blockList;
    [HideInInspector]
    public float spawnDelayInSeconds;
    private float elapsedTime;

    private Vector3 blockSpawnOffset = new Vector2(0, 7f);
    private Vector3 spawnPos;

    public int blocksSpawned;

    private void Start()
    {
        blockList = new List<GameObject>();
        spawnPos = this.transform.position;
        spawnDelayInSeconds = .2f;
    }

    private void SpawnBlocksOnTimer()
    {
        if(blockList.Count < blocksSpawned)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > spawnDelayInSeconds)
            {
                spawnDelayInSeconds = 1.5f;
                elapsedTime = 0;

                blockList.Add(Instantiate(blockPrefab, spawnPos, Quaternion.identity, this.transform));
                spawnPos -= blockSpawnOffset;
            }
        }
        
    }

    private void Update()
    {
        SpawnBlocksOnTimer();
    }
}
