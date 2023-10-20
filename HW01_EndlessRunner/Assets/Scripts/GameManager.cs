using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver;

    //I want game manager to keep track of time
    private float time;

    //Game manager also keeps track of player score
    private static float totalPlayerScore;
    private static bool b = true;

    // Start is called before the first frame update
    void Start()
    {
        setGameOver(false);
        time = 0;

        //I need to do this or else it keeps reseting my score to 0. Probably because Gamemanager script is open in multiple areas
        if (b)
        {
            totalPlayerScore = 0;
            b = false;
        }
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
            Time.timeScale = 0f;
        }
        else
        {
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
        //Debug.Log(totalPlayerScore);
    }

    public float getTotalPlayerScore()
    {
        return totalPlayerScore;
    }

    public void setTotalPlayerScoreOnGameEnd(float s)
    {
        totalPlayerScore = s;
    }
    //Score Stuff
    //===========

    public float getTime()
    {
        return time;
    }
}