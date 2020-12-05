using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerStartPos;

    private void Start()
    {
        playerStartPos = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Next Level");
            player.transform.position = playerStartPos;
        }
    }
}
