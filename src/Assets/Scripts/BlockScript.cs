using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour, IBreakable
{
    public List<GameObject> sceneObjects { get; set; }

    public int amountOfObjects { get; set; }
    public List<GameObject> objectsToRemove { get; set; }

    public GameObject blockPrefab;

    void Awake()
    {
        amountOfObjects = 120;
        PopulateSceneList();
    }

    void Update()
    {
        
    }

    public void Destroy()
    {
        this.enabled = false; // Change this later
    }

    public void PopulateSceneList()
    {
        sceneObjects = new List<GameObject>();
        objectsToRemove = new List<GameObject>();
        //Random.Range(-6.27f, 5.658f), Random.Range(-5.96f, -488.21f)
        //Transform limeTransform = Instantiate(prefabLime, new Vector3(UnityEngine.Random.Range(-12f, 25f), UnityEngine.Random.Range(-5f, 30f), UnityEngine.Random.Range(-8f, 20f)), Quaternion.identity);
        for (int i = 0; i < amountOfObjects; i++)
        {
            Vector2 position = new Vector2(Random.Range(-6.27f, 5.658f), Random.Range(-5.96f, -488.21f));
            sceneObjects.Add((GameObject)Instantiate(blockPrefab, position, Quaternion.identity, this.transform));                 
        }
    }   
}
