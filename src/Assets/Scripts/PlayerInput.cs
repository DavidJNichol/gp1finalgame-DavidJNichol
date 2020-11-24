using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // COMPONENTS --------
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;     
    public InputSystem inputSystem; 
    // -------------------

    // BULLETS -----------
    public GameObject bulletPrefab; // Self explanatory
    private Vector3 bulletSpawnPos; // Location on bullet instantiation
    private List<GameObject> spawnedBulletList; // List of bullets spawned and in the scene
    private bool allowFire = true; // Does the player have ammunition left?
    private int bullets = 20; // Magazine capacity
    private float fireDelay = .15f; // Delay between bullets
    private float firingTimer; // Timer used in shooting fire rate
    public float bulletForce; // Bullet speed on spawn
    // ------------------

    // MOVE -------------
    private Vector2 rigidVelocityRef = Vector2.zero; // Velocity ref used in vector smoothing
    public float moveVelocity; // Magnitude of horizontal movement
    private Vector2 targetVelocity; // Ideal velocity to smooth to
    private Vector2 jumpVector = new Vector2(0, .5f); // Used to apply force in the up direction
    public float jumpForce; // Magnitude of jump
    public float jumpGravity; // How much you will be pulled down when you reach a max y speed threshold
    // ------------------

    void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spawnedBulletList = new List<GameObject>();
        targetVelocity = new Vector2(moveVelocity * 10, rigidBody.velocity.y);
    }

    // INPUT ---------------------------
    private void HandleHorizontalInput()
    {
        if (inputSystem.CheckLeft())
        {
            rigidBody.velocity -= Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref rigidVelocityRef, .05f) * Time.deltaTime;
            FlipSpriteX(true);
        }

        if (inputSystem.CheckRight())
        {
            rigidBody.velocity += Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref rigidVelocityRef, .05f) * Time.deltaTime;
            FlipSpriteX(false);
        }
    }

    private void FlipSpriteX(bool status)
    {
        spriteRenderer.flipX = status;
    }

    private void HandleJump()
    {
        if (inputSystem.CheckSpacebar())
        {
            rigidBody.AddForce(jumpVector * jumpForce, ForceMode2D.Impulse);
        }
    }
    // ----------------------------------


    // SHOOT ----------------------------
    private void HandleShoot()
    {
        if (inputSystem.CheckSpacebar() && Time.time > firingTimer)
        {
            firingTimer = Time.time + fireDelay;
            Shoot();
        }
    } 

    private void Shoot()
    {
        SpawnBullet();
        bullets--; // Decrease player ammo left
    }

    private void SpawnBullet()
    {
        UpdateBulletSpawnLocation();
        GameObject spawnedBullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPos, Quaternion.identity, this.transform); 
        spawnedBulletList.Add(spawnedBullet);
    }

    private void UpdateBulletSpawnLocation()
    {
        bulletSpawnPos.x = this.transform.position.x;
        bulletSpawnPos.y = this.transform.position.y - 1; // Bullet starts 1 unit below the player before moving
    }

    private void MoveBullets()
    {
        if(spawnedBulletList != null)
        {
            for (int i = 0; i < spawnedBulletList.Count; i++)
            {
                if(spawnedBulletList[i] != null)
                    spawnedBulletList[i].transform.position += new Vector3(0, -bulletForce, 0); // Move bullet by a scale of bulletForce on the y on Update.
            }
        }
    }

    // ----------------------------------

    public void Update()
    {
        HandleShoot();

        if (bullets < 0)
        {
            allowFire = false;
        }
    }

    private void FixedUpdate()
    {
        ControlSpeed();
        HandleHorizontalInput();
        HandleJump();
        MoveBullets();
    }

    private void ControlSpeed()
    {
        if(rigidBody.velocity.y > 4)
        {
            rigidBody.AddForce(new Vector2(0,-jumpGravity));
        }
    }

    // Old firing timer ------

    //firingTimer -= Time.deltaTime;
    //if (firingTimer <= 0)
    //{
    //    SpawnBullet();
    //    firingTimer += fireDelay; // Delay = time between shots, firingTimer is set to 0
    //}

    // Old firing timer ------
}
