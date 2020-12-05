using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBoundryCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.SetActive(false); // Cull bullet when it reaches the bottom of the scene
        }
    }
}
