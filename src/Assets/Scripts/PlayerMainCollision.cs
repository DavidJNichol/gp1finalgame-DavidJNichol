using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMainCollision : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Text livesText;
    private int amountOfLives = 4;

    private void Start()
    {
        livesText.text = amountOfLives.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.GetComponent<BoxCollider2D>().IsTouching(collision)) // Makes sure bullets dont trigger this collision (i don't know why they do, they just do) 
        {
            if (collision.gameObject.tag == "Buggy" || collision.gameObject.tag == "Imp")
            {
                rigidbody.AddForce(new Vector2(Random.Range(15, 25), Random.Range(10, 15)), ForceMode2D.Impulse);
                amountOfLives--;
                livesText.text = amountOfLives.ToString();
                Debug.Log("Ow");
            }
        }       
    }
}
