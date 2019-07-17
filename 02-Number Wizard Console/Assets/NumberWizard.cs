using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    private int highestNum;
    private int lowestNum;
    private int guess;

    // Start is called before the first frame update
    void Start()
    {
        StartGameInfo();
    }

    private void StartGameInfo()
    {
        highestNum = 1000;
        lowestNum = 1;
        guess = 500;

        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("Pick a number");
        Debug.Log("The highest number you can pick is: " + highestNum);
        Debug.Log("The lowest number you can pick is: " + lowestNum);
        Debug.Log("Our guess is" + guess);
        Debug.Log("Press Up = higher, Down = lower, Enter = correct number");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up");
            lowestNum = guess;
            RestartGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down");
            highestNum = guess;
            RestartGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I win");
            StartGameInfo();

        }
    }

    private void RestartGuess()
    {
        guess = (highestNum + lowestNum) / 2;
        Debug.Log("Is you number: " + guess);
    }
}
