using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EasyUI.Toast;
using System;

public class sceneTimer : MonoBehaviour 
{

    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Rigidbody2D redDiamond;
    [SerializeField]
    private Rigidbody2D blueDiamond;

    private int minutesTimer, secondsTimer;
    private int VELOCIDAD = 25;

    public gameInformation gameInfo;
    public floorCollision floor;
    public roofCollision roof;
    public palmCenterCollision palm;

    private int collisions_with_the_hand = 0;
    private int score = 0;
    private int maximum_response = 0;
    private int minimum_response = 0;
    private float average_response = 0f;
    private int hits_left_arm = 0;
    private int hits_right_arm = 0;
    private float accuracy_percentage = 0f;
    private int failures_right_arm = 0;
    private int failures_left_arm = 0;

    public AudioSource audioSource;
    public AudioClip music_one;
    public AudioClip music_two;
    public AudioClip music_three;
    public AudioClip music_four;
    public AudioClip music_five;
    public AudioClip music_six;
    public AudioClip music_seven;
    public AudioClip music_eight;
    public AudioClip music_nine;
    public AudioClip music_ten;
    public AudioClip music_eleven;
    public AudioClip music_twelve;


    private void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    private void Start()
    {
        gameInfo = FindObjectOfType<gameInformation>();
        redDiamond.velocity = new Vector2(redDiamond.velocity.x, VELOCIDAD);
        blueDiamond.velocity = new Vector2(blueDiamond.velocity.x, -VELOCIDAD);
        musicSelected();
        startTimer(TimeSpan.FromSeconds(audioSource.clip.length).Minutes, TimeSpan.FromSeconds(audioSource.clip.length).Seconds);
        audioSource.Play();
        floor = FindObjectOfType<floorCollision>();
        roof = FindObjectOfType<roofCollision>();
        palm = FindObjectOfType<palmCenterCollision>();
    }


    public void musicSelected()
    {
        switch (gameInfo.nameMusic)
        {
            case "music_one": audioSource.clip = music_one; break;
            case "music_two": audioSource.clip = music_two; break;
            case "music_three": audioSource.clip = music_three; break;
            case "music_four": audioSource.clip = music_four; break;
            case "music_five": audioSource.clip = music_five; break;
            case "music_six": audioSource.clip = music_six; break;
            case "music_seven": audioSource.clip = music_seven; break;
            case "music_eight": audioSource.clip = music_eight; break;
            case "music_nine": audioSource.clip = music_nine; break;
            case "music_ten": audioSource.clip = music_ten; break;
            case "music_eleven": audioSource.clip = music_eleven; break;
            case "music_twelve": audioSource.clip = music_twelve; break;
        }
    }

    public void startTimer(int minuteTimer, int secondTimer)
    {
        minutesTimer = minuteTimer;
        secondsTimer = secondTimer;
        writeTimer(minutesTimer, secondsTimer);
        Invoke("updateTimer", 1f);
    }

    public void stopTimer()
    {
        CancelInvoke();
        audioSource.Stop();
        collisions_with_the_hand = (palm.numberOfDiamondBlueCollisionsWithTheHand + palm.numberOfDiamondRedCollisionsWithTheHand);
        score = collisions_with_the_hand * 5;
        maximum_response = (int) palm.maximum_response;
        minimum_response = (int) palm.minimum_response;
        average_response = (float)((palm.maximum_response + palm.minimum_response)/2);
        hits_left_arm = palm.numberOfDiamondRedCollisionsWithTheHand;
        hits_right_arm = palm.numberOfDiamondBlueCollisionsWithTheHand;
        failures_right_arm = (floor.numberOfDiamondBlueCollisionsWithTheFloor + roof.numberOfDiamondBlueCollisionsWithTheRoof);
        failures_left_arm = (floor.numberOfDiamondRedCollisionsWithTheFloor + roof.numberOfDiamondRedCollisionsWithTheRoof);
        accuracy_percentage = ((float)collisions_with_the_hand / ((float)collisions_with_the_hand + (float)failures_right_arm + (float)failures_left_arm));
        gameInfo.recordSceneInformationRhythmGame(score, maximum_response, minimum_response, average_response, hits_left_arm, hits_right_arm, accuracy_percentage, failures_right_arm, failures_left_arm);
        SceneManager.LoadScene("end game");
    }

    public void updateTimer()
    {
        secondsTimer--;
        if (secondsTimer < 0)
        {
            if (minutesTimer == 0)
            {
                stopTimer();
                //return;

            }
            else 
            {
                minutesTimer--;
                secondsTimer = 59;
            }
        }
        writeTimer(minutesTimer, secondsTimer);
        Invoke("updateTimer", 1f);
    }

    private void writeTimer(int minuteTimer,int secondTimer) 
    {
        if (secondTimer < 10)
        {
            timerText.text = "0" + minuteTimer.ToString() + ":0" + secondTimer.ToString();
        }
        else
        {
            timerText.text = "0" + minuteTimer.ToString() + ":" + secondTimer.ToString();
        }
    }

}
