using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private bool gameOver;

    //I want game manager to keep track of time
    private float time;
    
    //Game manager also keeps track of player score
    private static float totalPlayerScore = 0;
    private static bool b = true;

    private List<int> highScores = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        setGameOver(false);
        time = 0;

        //I need to do this or else it keeps reseting my score to 0. Probably because Gamemanager script is open in multiple areas
        //if (b)
        //{
        //    totalPlayerScore = 0;
        //    b = false;
        //}
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

            highScores = GetComponent<SaveData>().loadData();

            highScores.Add((int)totalPlayerScore);

            highScores.Sort();

            //If the list is already 5 in lenght (or more), then remove the lowest (which is already [0] since we sorted it)
            //Then save the whole thing to the saved data (should only be a list of size 5 since that's all we need)
            highScores.Remove(highScores[0]);
            GetComponent<SaveData>().saveData(highScores);
            

            //for (int i = 0; i < highScores.Count; i++)
            //{
                //Debug.Log(highScores[i]);
            //}

            totalPlayerScore = 0;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void sortList()
    {

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

    public float getTime()
    {
        return time;
    }
}