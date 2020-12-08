using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMainCollision : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Text livesText;

    public LivesManager livesManager;

    public SpriteRenderer spriteRenderer;

    private int forceXMin = 15;
    private int forceXMax = 25;
    private int forceYMin = 10;
    private int forceYMax = 15;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            rigidbody.AddForce(-new Vector2(collision.gameObject.transform.position.x - this.transform.position.x, collision.gameObject.transform.position.y - this.transform.position.y) * 20, ForceMode2D.Impulse); // Adds an impulse to the player's rigidbody in the opposite direction on hit with monster        
            livesManager.amountOfLives--;
            StartCoroutine(FlashSprite(collision));
            collision.rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private IEnumerator FlashSprite(Collision2D collision)
    {       
        spriteRenderer.color = new Color(200, 0, 0, .9f); // set sprite red
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = new Color(1, 1, 1, 1); // set sprite white
    }
}
