using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private float timer;
    private float delayAmount;
    private static int totalScore;
    public TMP_Text scoreGUI;

    // Start is called before the first frame update
    void Start()
    {
        delayAmount = 1f;
        totalScore = 0;
    }

    void Update()
    {
        //I want to increase the score by 4 every second
        timer += Time.deltaTime;
        if (timer >= delayAmount)
        {
            timer = 0f;
            setPlayerScore(1);
        }
    }

    public int getScore()
    {
        return totalScore;
    }

    public void setPlayerScore(int val)
    {
        totalScore += val;

        scoreGUI.text = "Score: " + totalScore.ToString();
    }
}
