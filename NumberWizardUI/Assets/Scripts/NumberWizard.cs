using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class NumberWizard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }

    public void OnPressHigher()
    {
        min = guess;
        NextGuess();
    }
    public void OnPressLower()
    {
        max = guess;
        NextGuess();
    }
}
