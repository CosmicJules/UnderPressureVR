using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnimation : MonoBehaviour
{
    //Script plays audio from an audio source when this script is called, will only play once

    AudioSource audioData;
    bool played = false;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        
        Debug.Log("started");
    }

    public void playAnimSound()
    {
        if (played == false)
        {
            audioData.Play();
            played = true;
        }
    }
}
