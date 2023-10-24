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
    private float minuteTimer;
    private int minutesPassed;
    
    //Game manager also keeps track of player score
    private static float totalPlayerScore = 0;

    private List<int> highScores = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        setGameOver(false);
        time = 0;
        minuteTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        hasMinutePassed();
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

    //=========================
    //Time and spawn rate stuff
    public float getTime()
    {
        return time;
    }

    //Keeps track of how many minutes have passed
    private void hasMinutePassed()
    {
        if (minuteTimer >= 60)
        {
            minuteTimer = 0;
            minutesPassed++;
            changeSpawnTimes();
        }
        else
        {
            minuteTimer += Time.deltaTime;
        }
    }

    private void changeSpawnTimes()
    {
        //Everything here will be hardcoded. Enemy spawn rates will keep speeding up until it reaches a "max speed" at 10 minutes
        if (minutesPassed == 1) 
        {
            GetComponent<BasicEnemySpawner>().setTimeBetweenSpawns(4f);
            GetComponent<ZigZagEnemySpawner>().setTimeBetweenSpawns(8f);
            GetComponent<F8EnemySpawner>().setTimeBetweenSpawns(24f);
        }
        else if (minutesPassed == 2)
        {
            GetComponent<BasicEnemySpawner>().setTimeBetweenSpawns(3.8f);
            GetComponent<ZigZagEnemySpawner>().setTimeBetweenSpawns(7f);
            GetComponent<F8EnemySpawner>().setTimeBetweenSpawns(23f);
        }
        else if (minutesPassed == 3)
        {
            GetComponent<BasicEnemySpawner>().setTimeBetweenSpawns(3.6f);
            GetComponent<ZigZagEnemySpawner>().setTimeBetweenSpawns(6.5f);
            GetComponent<F8EnemySpawner>().setTimeBetweenSpawns(22f);
        }
        else if (minutesPassed == 4)
        {
            GetComponent<BasicEnemySpawner>().setTimeBetweenSpawns(3.4f);
            GetComponent<ZigZagEnemySpawner>().setTimeBetweenSpawns(6f);
            GetComponent<F8EnemySpawner>().setTimeBetweenSpawns(21f);
        }
        else if (minutesPassed == 5)
        {
            GetComponent<BasicEnemySpawner>().setTimeBetweenSpawns(3.3f);
            GetComponent<ZigZagEnemySpawner>().setTimeBetweenSpawns(5.5f);
            GetComponent<F8EnemySpawner>().setTimeBetweenSpawns(20f);
        }
        else if (minutesPassed == 6)
        {
            GetComponent<BasicEnemySpawner>().setTimeBetweenSpawns(3.2f);
            GetComponent<ZigZagEnemySpawner>().setTimeBetweenSpawns(5.25f);
            GetComponent<F8EnemySpawner>().setTimeBetweenSpawns(19f);
        }
        else if (minutesPassed == 7)
        {
            GetComponent<BasicEnemySpawner>().setTimeBetweenSpawns(3.1f);
            GetComponent<ZigZagEnemySpawner>().setTimeBetweenSpawns(5f);
            GetComponent<F8EnemySpawner>().setTimeBetweenSpawns(18f);
        }
        else if (minutesPassed == 8)
        {
            GetComponent<BasicEnemySpawner>().setTimeBetweenSpawns(3f);
            GetComponent<ZigZagEnemySpawner>().setTimeBetweenSpawns(4.5f);
            GetComponent<F8EnemySpawner>().setTimeBetweenSpawns(17f);
        }
        else if (minutesPassed == 9)
        {
            GetComponent<BasicEnemySpawner>().setTimeBetweenSpawns(2.5f); //Max Basic enemy spawn rate
            GetComponent<ZigZagEnemySpawner>().setTimeBetweenSpawns(4.25f);
            GetComponent<F8EnemySpawner>().setTimeBetweenSpawns(16f);
        }
        else if (minutesPassed == 10) //Max game speed
        {
            GetComponent<BasicEnemySpawner>().setTimeBetweenSpawns(2.5f);
            GetComponent<ZigZagEnemySpawner>().setTimeBetweenSpawns(4f); //Max Zig Zag enemy spawn rate
            GetComponent<F8EnemySpawner>().setTimeBetweenSpawns(15f); //Max F8 enemy spawn rate
        } //By this point, it's been 10 minutes and enemies spawn in very often, the player WILL die soon

        Debug.Log(minutesPassed + " minutes passed");
    }
    //Time and spawn rate stuff
    //=========================
}