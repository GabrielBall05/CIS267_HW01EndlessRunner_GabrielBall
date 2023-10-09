using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private static int totalScore;
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
        totalScore += val;

        scoreGUI.text = "Score: " + totalScore.ToString();
    }
}
