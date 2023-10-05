using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int totalScore;
    public TMP_Text scoreGUI;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
    }

    public int getScore()
    {
        return totalScore;
    }

    public void setPlayerScore(int val)
    {
        //Make totalScore += val to be an algorithm that adds score based on time and # of collectables collected
        totalScore += val;

        scoreGUI.text = "Score: " + totalScore.ToString();
    }
}
