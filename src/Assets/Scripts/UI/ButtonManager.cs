using System.Collections;
using System.Collections.Generic;
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
        levelManager.ResetLevel();
        postGame.SetActive(false);
    }

    public void ToggleLaser(bool status)
    {
        if (status)
            playerShoot.laser = true;
        else
            playerShoot.laser = false;

        levelManager.ResetLevel();
        postGame.SetActive(false);
    }

    public void SetLives()
    {
        livesManager.UpdateAmountOfLives(15);
        levelManager.ResetLevel();
        postGame.SetActive(false);
    }
    public void SetLives(int amount)
    {
        livesManager.UpdateAmountOfLives(amount);
    }

    public void SetAmmo()
    {
        playerShoot.UpdateAmountOfAmmo(13);
        levelManager.ResetLevel();
        postGame.SetActive(false);
    }
    
    public void SetAmmo(int amount)
    {
        playerShoot.UpdateAmountOfAmmo(amount);
    }
}
