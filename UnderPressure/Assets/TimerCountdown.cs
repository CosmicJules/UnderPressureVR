using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Script contains timer that will open door and play audio when time runs out, set to 10 minutes in unity
public class TimerCountdown : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    public GameObject door;
    public AudioSource audioData;
    bool played = false;

    public GameObject[] GraphCubes;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        //audioData = GetComponent<AudioSource>();
        //audioDataViolin = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                //Play 'time's up' noise
                if (played == false)
                {
                    audioData.Play();
                    played = true;
                }

                //Open Door
                door.GetComponent<MeshRenderer>().enabled = false;
                door.GetComponent<BoxCollider>().enabled = false;

                //Get data from flask application and set end time
                GraphCubes[1].GetComponent<getHRWeb>().getHrStream();

                GraphCubes[0].GetComponent<getHR>().GetEndTime();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
