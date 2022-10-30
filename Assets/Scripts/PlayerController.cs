using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public Transform playerTransform;
    public Sprite[] carTextures;
    public float maxTurnSpeed = 3.6f;
    private static float ySpeedStart = 3.2f;
    private float accelerationX = 0.0022f;
    float ySpeed = ySpeedStart;
    float moveX = 0f;
    private float leftBorder = -3.9f;
    private float rightBorder = 3.8f;
    public static int velocityLevel = 0;
    private float[] velocityLevels = new float[7]{
        ySpeedStart, 
        ySpeedStart+0.5f, 
        ySpeedStart+3f, 
        ySpeedStart+6f, 
        ySpeedStart+9.5f, 
        ySpeedStart+13f, 
        ySpeedStart+16f
    };

    void Start(){
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = carTextures[Data.carId];
    }

    void Update(){
        moveX = Input.GetAxisRaw("Horizontal");
        // if(playerTransform.position.x>rightBorder){
        //     playerTransform.position = new Vector2(rightBorder, playerTransform.position.y);
        // }else if(playerTransform.position.x<leftBorder){
        //     playerTransform.position = new Vector2(leftBorder, playerTransform.position.y);
        // }
    }

    void FixedUpdate() {
        ySpeed += 1/(ySpeed*20);
        maxTurnSpeed += accelerationX;
        if(playerTransform.position.x >= rightBorder && moveX > 0) moveX = 0;
        else if(playerTransform.position.x <= leftBorder && moveX < 0) moveX = 0;
        player.velocity = new Vector2(moveX * maxTurnSpeed*Time.timeScale, ySpeed*Time.timeScale);
        for(int i = 0; i<velocityLevels.Length; i++){
            if(velocityLevels[i]<=ySpeed){
                velocityLevel = i;
            }else{
                break;
            }
        }
    }
}
