using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightPlayerBoundry : MonoBehaviour
{
    public GameObject bossFightPlayerStartPos;
    public Shoot playerShoot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = bossFightPlayerStartPos.transform.position;
            playerShoot.bullets = playerShoot.maxAmmo;
        }
    }
}
