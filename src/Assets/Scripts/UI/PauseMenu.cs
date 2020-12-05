using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Text pauseMenu;

    void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if(Input.GetKey("escape"))
        {
            pauseMenu.gameObject.SetActive(true); // Show pause menu
            Time.timeScale = 0; // Pause time
        }
    }
}
