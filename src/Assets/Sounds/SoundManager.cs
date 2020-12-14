using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [HideInInspector]
    public AudioSource[] audioSourceArray;
    [HideInInspector]
    public List<AudioSource> audioSourceList;

    private void Start()
    {
        audioSourceArray = FindObjectsOfType<AudioSource>();
    }

    public void KillAudio()
    {
        foreach(AudioSource sound in audioSourceArray)
        {
            if(sound.isPlaying)
                sound.Stop();
        }
    }
    public void KillAudio(string name)
    {
        foreach (AudioSource sound in audioSourceArray)
        {
            if (sound.isPlaying)
            {
                if(sound.gameObject.name == name)
                    sound.Stop();
            }
                
        }
    }

    private void AddArrayElementsToList()
    {
        foreach(AudioSource sound in audioSourceArray)
        {
            audioSourceList.Add(sound);
        }
    }
}
