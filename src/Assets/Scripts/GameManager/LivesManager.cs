using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Text livesText;
    public int amountOfLives = 10;
    [HideInInspector]
    public int maxLives;

    public AudioSource wellSounds;
    public GameObject deathUI;

    // Start is called before the first frame update
    void Start()
    {
        maxLives = amountOfLives;
    }

    public void UpdateAmountOfLives(int amount)
    {
        maxLives = amount;
        amountOfLives = maxLives;
    }

    private void Update()
    {
        livesText.text = $"{amountOfLives}";

        HandleDeath();
    }

    private void HandleDeath()
    {
        if (amountOfLives <= 0)
        {
            deathUI.SetActive(true);
            Time.timeScale = 0;
            wellSounds.pitch = .75f;
        }
        else
        {
            deathUI.SetActive(false);
            wellSounds.pitch = 1;
        }
    }

}
