using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver;

    //I want game manager to also keep track of time
    private float time;

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

    public float getTime()
    {
        return time;
    }
}
