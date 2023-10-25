using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
//========================
//Name: Gabriel Ball
//Date: 09-27-23
//Desc: Ripoff Galaga Game
//========================

public class GameManager : MonoBehaviour
{
    private bool gameOver;

    //I want game manager to keep track of time
    private float time;
    
    //Game manager also keeps track of player score
    private static float totalPlayerScore = 0;

    private List<int> highScores = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        setGameOver(false);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }


    //===============
    //Game Over Stuff
    public bool getGameOver()
    {
        return gameOver;
    }

    public void setGameOver(bool b)
    {
        gameOver = b;
        evaluateGameState();
    }

    public void evaluateGameState()
    {
        if(gameOver)
        {
            //Stop game
            Time.timeScale = 0f;

            //Get the arraylist that is saved to a file (high scores)
            highScores = GetComponent<SaveData>().loadData();
            //Add the player's score even if it isn't even in the top 5 scores, just add it anyway
            highScores.Add((int)totalPlayerScore);
            //Sort it from lowest to highest
            highScores.Sort();
            //Remove the lowest (lowest after sorting would be the first one, so [0])
            highScores.Remove(highScores[0]);
            //Save the new array list back into that file
            GetComponent<SaveData>().saveData(highScores);
            
            //Testing
            //for (int i = 0; i < highScores.Count; i++)
            //{
                //Debug.Log(highScores[i]);
            //}

            //Reset player score
            totalPlayerScore = 0;
        }
        else
        {
            //Keep game in normal speed
            Time.timeScale = 1f;
        }
    }
    //Game Over Stuff
    //===============


    //===========
    //Score Stuff
    public void addToTotalPlayerScore(float s)
    {
        totalPlayerScore += s;
        //Debug.Log("Score: " + totalPlayerScore);
    }

    public float getTotalPlayerScore()
    {
        return totalPlayerScore;
    }
    //Score Stuff
    //===========

    public float getTime() //Get time
    {
        return time;
    }
}