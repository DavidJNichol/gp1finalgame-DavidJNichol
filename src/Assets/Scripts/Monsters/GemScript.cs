using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public GameObject gemPrefab;
    private List<GameObject> gemList;
    public float lerpSpeed;

    private float xScale = .3f;
    private float yScale = .4f;
    private int xMinForce = -5;
    private int xMaxForce = 5;
    private int yMinForce = 0;
    private int yMaxForce = 15;


    private void Start()
    {
        gemList = new List<GameObject>();
    }

    public void SpawnGems(Transform transform)
    {
        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            GameObject gem = GameObject.Instantiate(gemPrefab, transform.position, Quaternion.identity, this.transform);  //Spawn Gem 
            gem.transform.localScale = new Vector3(Random.Range(xScale, yScale), Random.Range(xScale, yScale), 0); // Random scale on spawn. 0 on the z
            gem.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(xMinForce, xMaxForce), Random.Range(yMinForce, yMaxForce)), ForceMode2D.Impulse); // Random impulse force set on spawn 
            gemList.Add(gem);
        }
    }

    public void MoveGemsToPlayer(Vector2 playerPosition)
    {
        if(gemList != null)
        {
            foreach (GameObject gem in gemList)
            {
                gem.transform.position = Vector2.Lerp(gem.transform.position, playerPosition, lerpSpeed); // Lerp Gems to player when they are spawned
            }
        }        
    }
}
