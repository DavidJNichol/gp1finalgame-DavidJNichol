using System.Collections;
using System.Collections.Generic;
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
        }
    }

    private void SetUpNewLevel()
    {
        postGame.SetMainCamActive(false);
        postGame.FadeTextIn();
    }
}
