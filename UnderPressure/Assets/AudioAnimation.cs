using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnimation : MonoBehaviour
{
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
