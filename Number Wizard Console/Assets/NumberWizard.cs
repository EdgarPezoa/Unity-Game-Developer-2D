using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int max;
    int min;
    int guess;

    void Start(){
        StartGame();
    }

    void StartGame(){
        max = 100;
        min = 1;
        guess = ( max / min ) / 2;
        
        Debug.Log("Welcome to number wizard");
        Debug.Log("Pick a number");
        Debug.Log("Highest number is: " + max);
        Debug.Log("Lowest number is: " + min);
        Debug.Log("Tell me if yout number is higher or lower than: " + guess);
        Debug.Log("Push up = Higher, Push down = Lower");
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Return)){
            Debug.Log("That's it");
            StartGame();
        }else if (Input.GetKeyDown(KeyCode.UpArrow)){
            min = guess;
            NextGuess();
        }else if (Input.GetKeyDown(KeyCode.DownArrow)){
            max = guess;
            NextGuess();
        }
    }

    void NextGuess(){
        guess = ( max + min ) / 2;
        Debug.Log("Is higher or lower than: " + guess);
    }
}
