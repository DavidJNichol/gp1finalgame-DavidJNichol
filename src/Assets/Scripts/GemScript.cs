using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public GameObject gemPrefab;

    private List<GameObject> gemList;

    public float lerpSpeed;

    private void Start()
    {
        gemList = new List<GameObject>();
    }

    public void SpawnGems(Transform transform)
    {
        for (int i = 0; i < Random.Range(1, 3); i++)
        {
            GameObject gem = GameObject.Instantiate(gemPrefab, transform.position, Quaternion.identity, this.transform);            
            gem.transform.localScale = new Vector3(Random.Range(.3f, .4f), Random.Range(.3f, .4f), 0);
            gem.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 5), Random.Range(0, 15)), ForceMode2D.Impulse);
            gemList.Add(gem);
        }
    }

    public void MoveGemsToPlayer(Vector2 playerPosition)
    {
        if(gemList != null)
        {
            foreach (GameObject gem in gemList)
            {
                gem.transform.position = Vector2.Lerp(gem.transform.position, playerPosition, lerpSpeed);
            }
        }        
    }
}
