using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    // Block on block collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            this.transform.position = new Vector2(Random.Range(-6.27f, 5.658f), Random.Range(-5.96f, -488.21f)); // Stop blocks from spawning inside each other
        }
    }

    //Bullet collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("We got a collision");
            this.gameObject.SetActive(false); // "Destroy" block
            collision.gameObject.SetActive(false); // Maybe we should move them off the map rather than destroy for performance reasons?
            //collision.gameObject.transform.position = new Vector3();
        }
    }
}
