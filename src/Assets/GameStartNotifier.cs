using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartNotifier : MonoBehaviour
{
    [HideInInspector]
    public bool isGameStarted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            isGameStarted = true; // Player must hit this collider when they fall, thus game is started and spawn collision is turned off
        Debug.Log(isGameStarted);
    }
}
