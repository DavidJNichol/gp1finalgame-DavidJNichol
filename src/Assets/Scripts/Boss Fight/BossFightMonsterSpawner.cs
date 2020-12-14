using System.Collections.Generic;
using UnityEngine;

public class BossFightMonsterSpawner : MonoBehaviour
{
    public GameObject impPrefab;
    public GameObject buggyPrefab;
    private List<GameObject> monsterList;
    public GameStartNotifier gameStart;
    private float elapsedTime;
    private float spawnDelayInSeconds = 1;
    public int monstersToSpawn = 5;

    private void Start()
    {
        monsterList = new List<GameObject>();
    }

    private void SpawnMonstersOnTimer()
    {
        if(monsterList.Count < monstersToSpawn) // while there are less than 5 monsters in scene, spawn more
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > spawnDelayInSeconds)
            {
                elapsedTime = 0;

                if(Random.Range(0,2) % 2 == 0) // odd for imp, even for buggy
                {
                    GameObject buggy = (Instantiate(buggyPrefab, this.transform.position, Quaternion.identity, this.transform));
                    monsterList.Add(buggy);

                    if(buggy.gameObject.activeSelf == false)
                    {
                        buggy.SetActive(true); // enable them even if all objects tagged monster are disabled
                    }
                    
                }
                else
                {
                    GameObject imp = (Instantiate(impPrefab, this.transform.position, Quaternion.identity, this.transform));
                    monsterList.Add(imp);

                    if (imp.gameObject.activeSelf == false)
                    {
                        imp.SetActive(true);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnMonstersOnTimer();

        if(monsterList != null)
        {
            gameStart.isGameStarted = true; // used to stop monsters from resetting position on block collision
        }

        for(int i = 0; i < monsterList.Count; i++)
        {
            monsterList[i].GetComponent<AIMovement>().bossMonster = true; // makes it so that the monsters have no detection radius

            if (monsterList[i].gameObject.activeSelf == false)
            {
                monsterList.Remove(monsterList[i]); // removed dead monsters from list
            }
        }
    }
}
