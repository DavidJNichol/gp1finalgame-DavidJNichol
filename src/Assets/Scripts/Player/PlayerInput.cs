using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // COMPONENTS --------
    private Rigidbody2D rigidBody;  
    public InputSystem inputSystem;
    public PlayerBottomCollision playerBottomCollision;
    // -------------------

    // BULLETS -----------
    //public GameObject bulletPrefab; // Self explanatory
    //private Vector3 bulletSpawnPos; // Location on bullet instantiation
    //private List<GameObject> spawnedBulletList; // List of bullets spawned and in the scene
    //private bool allowFire = true; // Does the player have ammunition left?
    //private int bullets = 5; // Magazine capacity
    //private float fireDelay = .15f; // Delay between bullets
    //private float firingTimer; // Timer used in shooting fire rate
    //public float bulletForce; // Bullet speed on spawn
    //public float bulletSpawnOffset;
    // ------------------

    // MOVE -------------
    private Vector2 rigidVelocityRef = Vector2.zero; // Velocity ref used in vector smoothing
    public float moveVelocity; // Magnitude of horizontal movement
    private Vector2 targetVelocity; // Ideal velocity to smooth to
    private Vector2 jumpVector = new Vector2(0, .5f); // Used to apply force in the up direction
    public float jumpForce; // Magnitude of jump
    public float jumpGravity; // How much you will be pulled down when you reach a max y speed threshold
    // ------------------

    Quaternion spriteFlipQuaternion;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        //spawnedBulletList = new List<GameObject>();
        targetVelocity = new Vector2(moveVelocity, rigidBody.velocity.y);
        spriteFlipQuaternion = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, 1);
        playerBottomCollision = GetComponentInChildren<PlayerBottomCollision>();
    }

    // INPUT ---------------------------
    private void HandleHorizontalInput()
    {
        if (inputSystem.CheckLeft())
        {
            rigidBody.velocity -= Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref rigidVelocityRef, .05f) * Time.deltaTime;
            FlipSprite(180);
        }

        if (inputSystem.CheckRight())
        {
            rigidBody.velocity += Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref rigidVelocityRef, .05f) * Time.deltaTime;
            FlipSprite(0);
        }
    }

    private void FlipSprite(int degrees)
    {
        spriteFlipQuaternion.y = degrees;
        this.transform.rotation = spriteFlipQuaternion; // We use a quaternion instead of spriteRenderer.flipx = true because the colliders don't follow otherwise
    }

    private void HandleJump()
    {
        if(GetComponent<Shoot>().allowFire)
        {
            if (inputSystem.CheckSpacebar())
            {
                rigidBody.AddForce(jumpVector * jumpForce, ForceMode2D.Impulse);
            }
        }        
    }

    private void ControlSpeed()
    {
        if (rigidBody.velocity.y > 4)
        {
            rigidBody.AddForce(new Vector2(0, -jumpGravity));
        }
    }
    // ----------------------------------


    // SHOOT ----------------------------
    //private void HandleShoot()
    //{
    //    if(allowFire)
    //    {
    //        if (inputSystem.CheckSpacebar() && Time.time > firingTimer)
    //        {
    //            firingTimer = Time.time + fireDelay;
    //            Shoot();
    //        }
    //    }       
    //} 

    //private void Shoot()
    //{
    //    SpawnBullet();
    //    bullets--; // Decrease player ammo left
    //}

    //private void SpawnBullet()
    //{
    //    UpdateBulletSpawnLocation();
    //    GameObject spawnedBullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPos, Quaternion.identity, this.transform); 
    //    spawnedBulletList.Add(spawnedBullet);
    //}

    //private void UpdateBulletSpawnLocation()
    //{
    //    bulletSpawnPos.x = this.transform.position.x;
    //    bulletSpawnPos.y = this.transform.position.y - bulletSpawnOffset; // Bullet starts .5 units below the player before moving
    //}

    //private void MoveBullets()
    //{
    //    if(spawnedBulletList != null)
    //    {
    //        for (int i = 0; i < spawnedBulletList.Count; i++)
    //        {
    //            if(spawnedBulletList[i] != null)
    //                spawnedBulletList[i].transform.position += new Vector3(0, -bulletForce, 0); // Move bullet by a scale of bulletForce on the y on Update.
    //        }
    //    }
    //}

    //private void CheckAmmo()
    //{
    //    if(bullets <= 0)
    //    {
    //        bullets = 0;
    //        allowFire = false;
    //    }
    //    if(playerBottomCollision.isTouchingGround)
    //    {
    //        allowFire = true;
    //        bullets = 5;
    //    }
    //}

    // ----------------------------------



    private void FixedUpdate()
    {
        ControlSpeed();
        HandleHorizontalInput();
        HandleJump();
        //MoveBullets();
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
