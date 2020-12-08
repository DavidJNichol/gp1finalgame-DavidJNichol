using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;
    public GameObject player;
    private Vector3 playerStartPos;
    public LivesManager livesManager;
    public Shoot playerShoot;
    public GemScript gems;
    public PostGame postGame;
    public ButtonManager buttonManager;
    public MonsterRespawner monsterRespawner;

    private void Start()
    {
        playerStartPos = player.transform.position;
    }

    public void IncrementLevel()
    {
        level++;
    }

    public void ResetLevel()
    {
        player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        buttonManager.SetAmmo(playerShoot.maxAmmo);
        player.transform.position = playerStartPos;
        postGame.SetMainCamActive(true);        
    }

    public void StartNewGame()
    {
        gems.reset = true;
        ResetLevel();
        livesManager.UpdateAmountOfLives(10);
        playerShoot.UpdateAmountOfAmmo(9);
        gems.reset = false;

        monsterRespawner.TearDownScene();
        monsterRespawner.SpawnBlocks();
        monsterRespawner.SpawnBuggies();
        monsterRespawner.SpawnImps();

        buttonManager.ToggleLaser(false);
        buttonManager.SetAmmo(9);
        buttonManager.SetLives(10);
    }
}
