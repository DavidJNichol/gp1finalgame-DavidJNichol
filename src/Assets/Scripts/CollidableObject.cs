using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    protected enum Object
    { 
        Buggy,
        Imp,
        Block,
        Player
    }

    protected Object sceneObject;

    private float yMinBound = -5.96f;
    private float yMaxBound = -488.21f;
    private float xMaxBound = 5.658f;
    private float xMinBound = -6.27f;

    protected Transform childClassTransform = null;

    protected int gemsCollected;

    [HideInInspector]
    public bool isTouchingGround; //  public is bad. must be public bc player input has to access it

    [SerializeField]
    private GemScript gems; // FIND OUT A WAY TO NOT SERIALIZE THIS

    private void OnCollisionEnter2D(Collision2D collision) // Spawn collision for monsters (be careful with this if you decide to make monsters not a trigger)
    {
        // BUGGY COLLISION 
        if (sceneObject == Object.Buggy || sceneObject == Object.Imp) // Buggy checks for ground, imp and buggy on spawn
        {
            if (collision.gameObject.gameObject.tag == "Ground")
            {
                this.transform.position = new Vector2(Random.Range(xMinBound, xMaxBound), Random.Range(yMinBound, yMaxBound)); // If there is a collision, set a new spawn pos within boundries
            }
            if (collision.gameObject.gameObject.tag == "Monster")
            {
                this.transform.position = new Vector2(Random.Range(xMinBound, xMaxBound), Random.Range(yMinBound, yMaxBound));
            }
            //if (collision.gameObject.tag == "Buggy")
            //{
            //    this.transform.position = new Vector2(Random.Range(xMinBound, xMaxBound), Random.Range(yMinBound, yMaxBound));
            //}
        }

        // BLOCK COLLISION
        if (sceneObject == Object.Block)  // Block is not a trigger, so we must use collisionenter2d seperately for block on block spawn collision
        {
            if (collision.gameObject.GetComponent<Collider2D>().tag == "Ground")// Block checks for ground on spawn
            {
                this.transform.position = new Vector2(Random.Range(xMinBound, xMaxBound), Random.Range(yMinBound, -488.21f));
            }
        }

        // IMP COLLISION
        //if (sceneObject == Object.Imp) // Imp checks for ground, imp on spawn
        //{
        //    if (collision.gameObject.gameObject.tag == "Monster")
        //    {
        //        this.transform.position = new Vector2(Random.Range(xMinBound, xMaxBound), Random.Range(yMinBound, yMaxBound));
        //    }
        //    if (collision.gameObject.gameObject.tag == "Ground")
        //    {
        //        this.transform.position = new Vector2(Random.Range(xMinBound, xMaxBound), Random.Range(yMinBound, yMaxBound));
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // BULLET TRIGGER 
        if(sceneObject == Object.Block || sceneObject == Object.Buggy || sceneObject == Object.Imp)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                this.gameObject.SetActive(false); // "Destroy" block
                collision.gameObject.SetActive(false); // sets bullet inactive // Maybe we should move them off the map rather than destroy for performance reasons? 

                if (childClassTransform != null)
                {
                    gems.SpawnGems(childClassTransform);
                }
            }
        }
        
        // PLAYER TRIGGER 
        if (sceneObject == Object.Player) // Used for checking the player's feet collider
        {
            if (collision.gameObject.tag == "ImpTop" || collision.gameObject.tag == "BuggyTop")
            {
                //isTouchingGround = true; // Why does this not work?
                collision.gameObject.transform.parent.gameObject.SetActive(false); // Disables parent, which is the whole object since the top collider is a child
                gems.SpawnGems(collision.gameObject.transform);
            }

            if (collision.gameObject.tag == "GroundTop") // This reloads player's weapon
            {
                isTouchingGround = true;
            }

            if (collision.gameObject.tag == "Gem") // Make gems disabled and add 1 to gem counter, gem counter communication is done in playerBottomCollision.cs
            {
                collision.gameObject.SetActive(false);
                gemsCollected++;
            }
        }
    }
}
