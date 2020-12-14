using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PostGame : MonoBehaviour
{
    public Camera mainCam;
    public Camera postGameCam;
    public Text intermissionText;
    public Text powerUpText;
    public CanvasGroup canvasGroup;
    private Color fadeInColor;
    private string[] messageList;
    public AudioSource ominousSound;
    public AudioSource portalSound;
    public LevelManager levelManager;
    public GameObject bossFight;


    private void Start()
    {
        postGameCam.gameObject.SetActive(false); 
        intermissionText.color = new Color(0, 0, 0, 0); // hidden color
        canvasGroup.alpha = 0; // canvas group is hidden
        powerUpText.color = new Color(0, 0, 0, 0); // hidden color
        // Random message during intermission
        messageList = new string[4] { "The Well Cries For Your Blood", "What Terrible Horrors Lie Beyond?", "The Darkness Swells", "When You Gaze Long Into An Abyss, The Abyss Also Gazes Into You" }; 
        fadeInColor = new Color(255, 255, 255, 255);  // white color to lerp to      
    }

    public void SetMainCamActive(bool status)
    {
        if(status)
        {
            mainCam.gameObject.SetActive(true);
            postGameCam.gameObject.SetActive(false);
        }
        else
        {
            mainCam.gameObject.SetActive(false);
            postGameCam.gameObject.SetActive(true);
        }        
    }

    public void SetBossFightCam()
    {
        mainCam.GetComponent<CamScript>().followX = true; // follows player on x axis
        mainCam.gameObject.SetActive(true);
        bossFight.SetActive(true);
        postGameCam.gameObject.SetActive(false);
    }

    public void DisplayIntermission()
    {
        PlayIntermissionMusic();
        SelectRandomIntermissionMessage();
        StartCoroutine(FadeIn());
        StopCoroutine(FadeIn());
        ResetColor();
    }

    private IEnumerator FadeIn()
    {
        while (intermissionText.color.a < fadeInColor.a)
        { 
            intermissionText.color = Color.Lerp(intermissionText.color, fadeInColor, .0015f * Time.deltaTime); // lerp random message to white
            powerUpText.color = Color.Lerp(powerUpText.color, fadeInColor, .0015f * Time.deltaTime); // lerp "choose a power up" to white
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, .5f * Time.deltaTime); // lerp canvas group to visible
            yield return null;
        }      
    }

    private void SelectRandomIntermissionMessage()
    {        
        intermissionText.text = messageList[Random.Range(0,4)];
    }

    private void ResetColor()
    {
        intermissionText.color = new Color(0, 0, 0, 0);
        canvasGroup.alpha = 0;
        powerUpText.color = new Color(0, 0, 0, 0);
    }

    private void PlayIntermissionMusic()
    {
        ominousSound.Play();
    }

    public void PlayBossIntermission()
    {
        intermissionText.text = "NYARLATHOTEP HUNGERS"; // Boss text
        fadeInColor = fadeInColor = new Color(255, 0, 0, 255); // Red   
        PlayIntermissionMusic();
        StartCoroutine(FadeIn());
        StopCoroutine(FadeIn());
        ResetColor();
    }

}
