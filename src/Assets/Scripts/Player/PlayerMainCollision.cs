using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMainCollision : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Text livesText;
    public LivesManager livesManager;
    public SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            TakeDamage(collision);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation; // enables monster movement after player leaves collision
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Nyarlathotep")
        {
            if (GetComponent<BoxCollider2D>().IsTouching(collision)) // only if box collider is touching, not the edge collider 
            {
                TakeDamage(collision);
            }
        }       
    }

    private IEnumerator FlashSprite()
    {       
        spriteRenderer.color = new Color(200, 0, 0, .9f); // set sprite red
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = new Color(1, 1, 1, 1); // set sprite white
    }

    private void TakeDamage(Collision2D collision)
    {
        rigidbody.AddForce(-new Vector2(collision.gameObject.transform.position.x - this.transform.position.x, collision.gameObject.transform.position.y - this.transform.position.y) * 20, ForceMode2D.Impulse); // Adds an impulse to the player's rigidbody in the opposite direction on hit with monster        
        livesManager.amountOfLives--;
        StartCoroutine(FlashSprite());
        collision.rigidbody.constraints = RigidbodyConstraints2D.FreezeAll; // freeze monster movement to help with double collisions
    }

    private void TakeDamage(Collider2D collision) // Trigger2D version
    {
        rigidbody.AddForce(-new Vector2(collision.gameObject.transform.position.x - this.transform.position.x, collision.gameObject.transform.position.y - this.transform.position.y) * 20, ForceMode2D.Impulse); // Adds an impulse to the player's rigidbody in the opposite direction on hit with monster        
        livesManager.amountOfLives--;
        StartCoroutine(FlashSprite());
    }
}
