using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    // BULLETS -----------
    public GameObject bulletPrefab; // Self explanatory
    private Vector3 bulletSpawnPos; // Location on bullet instantiation
    private List<GameObject> spawnedBulletList; // List of bullets spawned and in the scene
    public bool allowFire = true; // Does the player have ammunition left?
    private int bullets; // Magazine capacity
    private float fireDelay = .15f; // Delay between bullets
    private float firingTimer; // Timer used in shooting fire rate
    public float bulletForce; // Bullet speed on spawn
    public float bulletSpawnOffset;
    public int maxAmmo;
    public Text ammoLeft;
    public GameObject bulletManager; // Used to organize bullets that are spawned
    // ------------------

    public bool laser;

    public GameObject laserPrefab;
    private Vector3 laserSpawnPos;
    private List<GameObject> spawnedLaserList;
    public float laserSpawnOffset;


    private void Awake()
    {
        spawnedBulletList = new List<GameObject>();
        spawnedLaserList = new List<GameObject>();
        bullets = maxAmmo;
    }

    private void HandleShoot()
    {
        if (allowFire)
        {
            if (GetComponent<PlayerInput>().inputSystem.CheckSpacebar() && Time.time > firingTimer)
            {
                firingTimer = Time.time + fireDelay;
                Fire();
            }
        }
    }

    private void Fire()
    {
        if (laser)
        {
            SpawnLaser();
        }
        else
        {
            SpawnBullet();
        }

        bullets--; // Decrease player ammo left
    }

    private void SpawnBullet()
    {
        UpdateBulletSpawnLocation();
        GameObject spawnedBullet = GameObject.Instantiate(bulletPrefab, bulletSpawnPos, Quaternion.identity, bulletManager.transform);
        spawnedBulletList.Add(spawnedBullet);
    }

    private void SpawnLaser()
    {
        UpdateBulletSpawnLocation();
        GameObject spawnedLaser = GameObject.Instantiate(laserPrefab, laserSpawnPos, Quaternion.identity, bulletManager.transform);
        spawnedLaserList.Add(spawnedLaser);
    }

    private void UpdateBulletSpawnLocation()
    {
        if(laser)
        {
            laserSpawnPos.x = this.transform.position.x;
            laserSpawnPos.y = this.transform.position.y - laserSpawnOffset;
        }
        else
        {
            bulletSpawnPos.x = this.transform.position.x;
            bulletSpawnPos.y = this.transform.position.y - bulletSpawnOffset; // Bullet starts .5 units below the player before moving
        }
    }

    private void MoveBullets()
    {
        if(laser)
        {
            if(spawnedLaserList != null)
            {
                for (int i = 0; i < spawnedLaserList.Count; i++)
                {
                    if (spawnedLaserList[i] != null)
                        spawnedLaserList[i].transform.position += new Vector3(0, -bulletForce, 0); // Move bullet by a scale of bulletForce on the y on Update.
                }
            }
        }
        else
        {
            if (spawnedBulletList != null)
            {
                for (int i = 0; i < spawnedBulletList.Count; i++)
                {
                    if (spawnedBulletList[i] != null)
                        spawnedBulletList[i].transform.position += new Vector3(0, -bulletForce, 0); // Move bullet by a scale of bulletForce on the y on Update.
                }
            }
        }        
    }

    private void CheckAmmo()
    {
        if (bullets <= 0)
        {
            bullets = 0;
            allowFire = false;
        }
        if (GetComponent<PlayerInput>().playerBottomCollision.isTouchingGround)
        {
            allowFire = true;
            bullets = maxAmmo;
        }
    }

    private void Update()
    {
        HandleShoot();
        ammoLeft.text = bullets.ToString();
        CheckAmmo();
    }

    private void FixedUpdate()
    {
        MoveBullets();
    }

}
