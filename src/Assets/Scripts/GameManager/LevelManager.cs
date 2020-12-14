using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level; // used to determine boss round or not
    public GameObject player;
    public Vector3 playerStartPos;
    public LivesManager livesManager;
    public Shoot playerShoot;
    public GemScript gems;
    public PostGame postGame;
    public ButtonManager buttonManager;
    public SceneRespawner sceneRespawner;
    public SoundManager soundManager;
    public GameObject playerBossStartPos;
    public GameObject playerStartLoc;
    public AudioSource bossMusic;
    public CamScript camScript;

    private void Start()
    {
        playerStartPos = playerStartLoc.transform.position;

    }

    public void IncrementLevel()
    {
        level++;
    }

    public void ResetLevel()
    {
        player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); // Stop player's rigid movement
        buttonManager.SetAmmo(playerShoot.maxAmmo); // reset ammo to max value
        buttonManager.SetLives(livesManager.maxLives); // reset lives to max value
        player.transform.position = playerStartPos; // reset player position
        postGame.SetMainCamActive(true); // reset camera
        soundManager.KillAudio(); // disable all sounds

        if (level != 3)
            RespawnEntities(); // if not boss level, respawn everything in main gameplay area
    }

    public void StartBossLevel()
    {
        player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        buttonManager.SetAmmo(playerShoot.maxAmmo);
        buttonManager.SetLives(livesManager.maxLives);
        player.transform.position = playerBossStartPos.transform.position;
        playerStartPos = playerBossStartPos.transform.position;
        postGame.SetBossFightCam(); // toggles boss camera and enable boss area gameobjects
        postGame.SetMainCamActive(true);
        soundManager.KillAudio();
        bossMusic.Play();
    }

    public void StartNewGame()
    {
        gems.reset = true; // gems = 0
        ResetLevel();

        livesManager.UpdateAmountOfLives(10); // default value for lives
        playerShoot.UpdateAmountOfAmmo(9); // default value for ammo
        buttonManager.ToggleLaser(false);
        if(level != 3)
            postGame.mainCam.GetComponent<CamScript>().followX = false; // if not boss level, camera does not follow player on the X axis
        camScript.ResetPosition(); // reset camera position
        //TOOK RESPAWN ENTITIES OUT HERE        
    }

    private void RespawnEntities()
    {
        sceneRespawner.TearDownScene(); // despawn all monsters and blocks
        sceneRespawner.SpawnBlocks();
        sceneRespawner.SpawnBuggies();
        sceneRespawner.SpawnImps();
    }
}
