using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Text pauseMenu;
    public Shoot playerShoot;
    int indexer;

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
        if(indexer %2 == 0)
            playerShoot.laser = true;
        else
            playerShoot.laser = false;

        indexer++;
    }
}
