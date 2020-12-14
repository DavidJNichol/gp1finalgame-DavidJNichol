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
    private int maxPositiveVerticalSpeed = 4;
    private int maxNegativeVerticalSpeed = -15;
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
        if (rigidBody.velocity.y > maxPositiveVerticalSpeed)
        {
            rigidBody.AddForce(new Vector2(0, -jumpGravity)); // Jumping control
        }
        if(rigidBody.velocity.y < maxNegativeVerticalSpeed)
        {
            rigidBody.AddForce(new Vector2(0, jumpGravity)); // Falling control
        }
    }
    // ----------------------------------

    private void FixedUpdate()
    {
        ControlSpeed();
        HandleHorizontalInput();
        HandleJump();
    }
}
