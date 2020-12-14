using System.Collections;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private Vector2 movementVector = new Vector2(2f,-.3f);
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    [HideInInspector]
    public int livesRemaining;
    private int lives;
    public PostGame postGame;
    public GameObject bossScene;

    private void Start()
    {
        lives = 35; // lives it starts with
        livesRemaining = lives;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BossCollider")
        {
            movementVector *= -1; // Flip direction
        }
        if(collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(FlashSprite()); //flash sprite red
            livesRemaining--;
        }

    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(movementVector, ForceMode2D.Impulse); // movement
    }

    private IEnumerator FlashSprite()
    {
        spriteRenderer.color = new Color(200, 0, 0, .9f); // set sprite red
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = new Color(1, 1, 1, 1); // set sprite white
    }

    private void Update()
    {
        if (livesRemaining <= 0)
        {
            //Win
            postGame.levelManager.level = 1;
            postGame.levelManager.playerStartPos = postGame.levelManager.playerStartLoc.transform.position; // reset player position to top of well
            bossScene.SetActive(false);
            postGame.levelManager.StartNewGame();            
        }
    }

}
