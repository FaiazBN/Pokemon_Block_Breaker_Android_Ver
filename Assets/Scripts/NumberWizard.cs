using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;

    void Start()
    {
        startGame();
    }

    void startGame()
    {
        nextGuess();
    }
    public void onPressHigher()
    {
        min = guess ;
        nextGuess();
    }
    public void onPressLower()
    {
        max = guess - 1;
        nextGuess();
    }  
    void nextGuess()
    {
        guess = Random.Range(min,max+1);
        guessText.text = guess.ToString();
    }
}
