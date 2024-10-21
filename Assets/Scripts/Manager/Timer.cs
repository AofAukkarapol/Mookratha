using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI minuteText;
    public TextMeshProUGUI secondText;
    Animator animator;

    [Header("Timer Setting")]
    public float currentTime;
    public bool countDown;
    public Animator clock;

    public GameObject[] PlayerGameObject;

    public GameObject SummaryUI;

    public GameObject timeUpSound;

    public GameObject BGMSound;
    public GameObject MenuSongSound;

    public GameObject[] Spawner;

    public bool isPlay = false;
    public GameObject playButton;


    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;



    private void Start()
    {
        clock.enabled = false;
        //currentTime = 180;
    }

    private void Update()
    {
        if (isPlay)
        {
            if (countDown && currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                minuteText.text = ((int)currentTime / 60).ToString();
                secondText.text = returnSecond((int)currentTime);
            }
        }

        if (Input.GetKeyDown("1"))
        {
            player1.Respawn();
        }
        if (Input.GetKeyDown("2"))
        {
            player2.Respawn();
        }
        if (Input.GetKeyDown("3"))
        {
            player3.Respawn();
        }
        if (Input.GetKeyDown("4"))
        {
            player4.Respawn();
        }

    }
    public void ClockShake()
    {
        clock.enabled = true;
        TimesUp();
    }

    private string returnSecond(int currentTime)
    {
        string returnString;
        returnString = (currentTime % 60).ToString();
        if (currentTime % 60 < 10) returnString = "0" + returnString;
        return returnString;
    }

    private void StopTime()
    {
        Debug.Log("TIME'S UP!");
        Time.timeScale = 0;
    }

    private void TimesUp()
    {
        Debug.Log("TIME'S UP!");
        
        if(PlayerGameObject.Length > 0)
        {
            for (int i = 0; i < PlayerGameObject.Length; i++)
            {
                if (PlayerGameObject[i] != null)
                {
                    Destroy(PlayerGameObject[i]);
                }
            }
        }
        

        SummaryUI.SetActive(true); 
        timeUpSound.SetActive(true);
        BGMSound.SetActive(false);
        MenuSongSound.SetActive(true);


      

    }


    public void onPlay()
    {
        isPlay = true;
        if (PlayerGameObject.Length > 0)
        {
            for (int i = 0; i < PlayerGameObject.Length; i++)
            {
                if (PlayerGameObject[i] != null)
                {
                    PlayerGameObject[i].SetActive(true);
                }
            }
        }

        playButton.SetActive(false);
    }
}
