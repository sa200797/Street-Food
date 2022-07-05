﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [Tooltip("Time To Enter in Seconds.")]
    [SerializeField] internal float timeRemaning = 10;
    public static bool timerIsRunning = false;

     public Image ObjectwithImage;
public Sprite spriteToChangeItTo;
public Sprite spriteToChangeItTo1;
    // Start is called before the first frame update
    void Start()
    {
        DisplayTimer(timeRemaning);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning == true)
        {
            if (timeRemaning > 0)
            {
                timeRemaning -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Game Over");
                timeRemaning = 0;
                timerIsRunning = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            DisplayTimer(timeRemaning);
        }       

    }

    void DisplayTimer(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        UIManager.instance.timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
      //  Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds)); // opy same line to display
        Debug.Log("........timeremaining........"+timeRemaning);
        Debug.Log("........timedisplay........."+minutes);
        if(minutes==1)
        {
              ObjectwithImage.sprite = spriteToChangeItTo;
        }
         if(minutes==0)
        {
              ObjectwithImage.sprite = spriteToChangeItTo1;
        }

    }
    public float AddTimer(float time)
    {
        timeRemaning = timeRemaning + time;
        return timeRemaning;
    }
}
