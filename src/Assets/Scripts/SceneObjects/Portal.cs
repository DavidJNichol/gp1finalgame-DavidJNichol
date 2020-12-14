using UnityEngine;

public class Portal : MonoBehaviour
{
    public PostGame postGame;
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            postGame.gameObject.SetActive(true);
            SetUpNewLevel();            
            levelManager.IncrementLevel();
            levelManager.soundManager.KillAudio("OminousWell");
        }
    }

    private void SetUpNewLevel()
    {
        postGame.SetMainCamActive(false);

        if (levelManager.level == 2) // check for boss level
            postGame.PlayBossIntermission();
        else
            postGame.DisplayIntermission();
    }
}
