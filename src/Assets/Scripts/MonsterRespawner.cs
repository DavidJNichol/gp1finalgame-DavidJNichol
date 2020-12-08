using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRespawner : SpawnableObject
{
    public BlockSpawner blockSpawner;
    public BuggySpawner buggySpawner;
    public ImpSpawner impSpawner;

    public GameObject parentBlock;
    public GameObject parentGemBlock;
    public GameObject parentBuggy;
    public GameObject parentImp;

    public GameStartNotifier gameStartNotifier;
    

    private void Start()
    {
        amountOfObjects = 120;
    }

    public void SpawnBlocks()
    {
        gameStartNotifier.isGameStarted = false;
        blockSpawner.SpawnRandomBlockType();
    }

    public void SpawnBuggies()
    {
        PopulateScene(buggySpawner.buggyPrefab, buggySpawner.transform);
    }

    public void SpawnImps()
    {
        PopulateScene(impSpawner.impPrefab, impSpawner.transform);
    }

    public void TearDownScene()
    {
        GameObject[] blockArray = GameObject.FindGameObjectsWithTag("Ground");
        GameObject[] monsterArray = GameObject.FindGameObjectsWithTag("Monster");

        foreach(GameObject block in blockArray)
        {
            block.gameObject.SetActive(false);
        }
        parentBlock.gameObject.SetActive(true); // set parent object active for spawn
        parentGemBlock.gameObject.SetActive(true);

        foreach(GameObject monster in monsterArray)
        {
            monster.gameObject.SetActive(false);
        }
        parentBuggy.gameObject.SetActive(true);
        parentImp.SetActive(true);
    }
}
