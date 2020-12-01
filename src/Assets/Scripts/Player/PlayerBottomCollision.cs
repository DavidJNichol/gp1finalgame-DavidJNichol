using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBottomCollision : CollidableObject
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private Vector2 jumpVector; // Used to apply force in the up direction
    [SerializeField]
    private float jumpForce; // Magnitude of jump
    [SerializeField]
    private GemScript gemScript;
    [SerializeField]
    private Text gemText;




    private void Start()
    {
        sceneObject = Object.Player; // From CollidableObject
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ImpTop" || collision.gameObject.tag == "BuggyTop")
        {
            isTouchingGround = false; // player is no longer touching ground, allow for shooting
            rigidBody.AddForce(jumpVector * jumpForce, ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag == "GroundTop")
        {
            isTouchingGround = false; // player is no longer touching ground, allow for shooting
        }
    }

    private void Update()
    {
        gemScript.MoveGemsToPlayer(this.transform.position); // Gems must collide with player bottom in order to disappear. Fix this - needs to be a collision (not trigger) with player main collider
        gemText.text = gemsCollected.ToString();
    }
}
