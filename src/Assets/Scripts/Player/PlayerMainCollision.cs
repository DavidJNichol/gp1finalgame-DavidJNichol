using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMainCollision : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Text livesText;
    private int amountOfLives = 10;
    public SpriteRenderer spriteRenderer;

    private int forceXMin = 15;
    private int forceXMax = 25;
    private int forceYMin = 10;
    private int forceYMax = 15;

    private void Start()
    {
        livesText.text = amountOfLives.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            rigidbody.AddForce(new Vector2(Random.Range(forceXMin, forceXMax), Random.Range(forceYMin, forceYMax)), ForceMode2D.Impulse); // Adds an impulse to the player's rigidbody in a random direction on hit with monster
            amountOfLives--;
            livesText.text = amountOfLives.ToString();
            StartCoroutine(FlashSprite());
        }
    }

    private IEnumerator FlashSprite()
    {
        spriteRenderer.color = new Color(200, 0, 0, .9f); // set sprite red
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = new Color(1, 1, 1, 1); // set sprite white
    }
}
