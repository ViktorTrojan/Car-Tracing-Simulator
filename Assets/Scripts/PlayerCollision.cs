using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioSource crashAudio;
	public AudioSource endAudio;
    public int menuSceneIndex = 0;
    public float delayEnd;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        delayEnd = 2f;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("NPC")){
            if(!GameLogic.hasGameEnded){
                GameLogic.hasGameEnded = true;
                Time.timeScale = 0.2f;
                endAudio.Play();
                Invoke(nameof(ChangeScene), delayEnd*Time.timeScale);
            }
            
        }
    }

    private void ChangeScene(){
        SceneManager.LoadScene(menuSceneIndex);
    }
}