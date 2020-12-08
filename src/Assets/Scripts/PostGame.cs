using System.Collections;
using System.Collections.Generic;
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
    private Color fadeOutColor;

    private string[] messageList;

    private void Start()
    {
        postGameCam.gameObject.SetActive(false);
        intermissionText.color = new Color(0, 0, 0, 0);
        canvasGroup.alpha = 0;
        powerUpText.color = new Color(0, 0, 0, 0);
        fadeInColor = new Color(255, 255, 255, 255);
        fadeOutColor = new Color(0, 0, 0, 0);
        messageList = new string[4] { "The Well Cries For Your Blood", "What Terrible Horrors Lie Beyond?", "The Darkness Swells", "When You Gaze Long Into An Abyss, The Abyss Also Gazes Into You" };
        SelectRandomIntermissionMessage();
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

    public void FadeTextIn()
    {
        StartCoroutine(FadeIn());        
    }

    private IEnumerator FadeIn()
    {
        while (intermissionText.color.a < fadeInColor.a)
        { 
            intermissionText.color = Color.Lerp(intermissionText.color, fadeInColor, .0008f * Time.deltaTime);
            powerUpText.color = Color.Lerp(powerUpText.color, fadeInColor, .0008f * Time.deltaTime);
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, .5f * Time.deltaTime);
            yield return null;
        }  
    }

    private void SelectRandomIntermissionMessage()
    {        
        intermissionText.text = messageList[Random.Range(0,4)];
    }
}
