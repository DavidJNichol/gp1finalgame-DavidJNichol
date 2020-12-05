using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Bullet")
        {           
            collision.gameObject.SetActive(false); // sets bullet inactive // Maybe we should move them off the map rather than destroy for performance reasons? 
            //collision.gameObject.transform.position = new Vector3(); 
        }

    }
}
