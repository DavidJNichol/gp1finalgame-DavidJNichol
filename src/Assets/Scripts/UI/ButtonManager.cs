using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Text pauseMenu;
    public Shoot playerShoot;
    public GameObject postGame;

    public LevelManager levelManager;
    public LivesManager livesManager;

    public void ExitGame()
    {
        Application.Quit(); // Quit Game
    }

    public void CloseMenu()
    {
        pauseMenu.gameObject.SetActive(false); // Hide pause menu
        Time.timeScale = 1; // Reset time back to normal
    }

    public void ToggleLaser()
    {
        playerShoot.laser = true;
        AdvanceLevel();
        postGame.SetActive(false);
    }

    public void ToggleLaser(bool status) // power up laser toggle
    {
        if (status)
            playerShoot.laser = true;
        else
            playerShoot.laser = false;

        AdvanceLevel();
        postGame.SetActive(false);
    }

    public void SetLives() // Lives power up
    {
        livesManager.UpdateAmountOfLives(15); 
        AdvanceLevel();
        postGame.SetActive(false);
    }
    public void SetLives(int amount) // Custom set lives
    {
        livesManager.UpdateAmountOfLives(amount);
    }

    public void SetAmmo() // Ammo power up
    {
        playerShoot.UpdateAmountOfAmmo(13);
        AdvanceLevel();
        postGame.SetActive(false);
    }
    
    public void SetAmmo(int amount) // Custom set ammo
    {
        playerShoot.UpdateAmountOfAmmo(amount);
    }

    public void Restart() // on death
    {
        levelManager.StartNewGame();
        Time.timeScale = 1;
    }

    public void ResetLevel() // pause menu version
    {
        levelManager.ResetLevel();
        Time.timeScale = 1;
    }

    public void SetBossFightActive() // pause menu skip to boss fight
    {
        levelManager.level = 3;
        levelManager.StartBossLevel();
        Time.timeScale = 1;
    }

    private void AdvanceLevel()
    {
        if (levelManager.level == 3)
            levelManager.StartBossLevel();
        else
            levelManager.ResetLevel();
    }
}
