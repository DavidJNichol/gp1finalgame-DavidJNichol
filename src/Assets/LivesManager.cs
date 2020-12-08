using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Text livesText;
    public int amountOfLives;
    public int maxLives = 10;
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        amountOfLives = maxLives;
    }

    public void UpdateAmountOfLives(int amount)
    {
        amountOfLives = amount;
    }

    private void Update()
    {
        livesText.text = $"{amountOfLives}";

        if (amountOfLives <= 0)
        {
            levelManager.StartNewGame();
        }     
    }

}
