using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocityIndicator : MonoBehaviour
{
    public GameObject velocityIndicator;
    public Sprite[] velocityTextures;
    private int currentIndex = 0;

    void Update(){
        if(currentIndex!=PlayerController.velocityLevel){
            currentIndex = PlayerController.velocityLevel;
            updateVelocityIndicator(currentIndex);
        }
    }

    private void updateVelocityIndicator(int index){
        velocityIndicator.GetComponent<Image>().sprite = velocityTextures[index];
    }
}
