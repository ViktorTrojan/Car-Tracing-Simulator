using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameLogic : MonoBehaviour
{
    public AudioSource backgroundAudio;
    public GameObject scoreText;
    private DateTime start;
    private int currentScore = 0;
    public static bool hasGameEnded;

    void Start(){
        hasGameEnded = false;
        backgroundAudio.Play();
        start = DateTime.Now;
        Time.timeScale = 1;
    }

    void Update(){
        if(hasGameEnded){
            backgroundAudio.Stop();
        }else{
            Data.score = (int)(DateTime.Now-start).TotalSeconds;
            if(currentScore!=Data.score){
                currentScore = Data.score;
                scoreText.GetComponent<Text>().text = "Score: "+currentScore;
            }
        }
    }

}
