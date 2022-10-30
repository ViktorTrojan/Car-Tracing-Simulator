using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuEvents : MonoBehaviour
{
    public Sprite defaultColor;
    public Sprite selectedColor;
    public GameObject[] cars;
    public GameObject scoreTextField;
    public AudioSource buttonClick;

    public void Start(){
        if(Data.score>Data.highScore){
            Data.highScore = Data.score;
        }
        drawCarButtonBackground(Data.carId);
        scoreTextField.GetComponent<Text>().text = "Score: "+Data.score+"\nHighscore: "+Data.highScore;
    }

    public void loadGame(int index) {
        buttonClick.Play();
        SceneManager.LoadScene(index);
    }

    public void quitGame() {
        buttonClick.Play();
        Application.Quit();
    }

    public void selectCar(int id) {
        buttonClick.Play();
        Data.carId = id;
        drawCarButtonBackground(Data.carId);
    }

    private void drawCarButtonBackground(int selectedCarId){
        int i = 0;
        foreach(GameObject car in cars){
            if(selectedCarId==i){
                car.GetComponent<Image>().sprite = selectedColor;
            }else{
                car.GetComponent<Image>().sprite = defaultColor;
            }
            i++;
        }
    }
}
