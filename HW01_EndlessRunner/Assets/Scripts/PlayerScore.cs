using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private float timer;
    private float delayAmount;
    private static float totalScore;
    public TMP_Text scoreGUI;

    // Start is called before the first frame update
    void Start()
    {
        delayAmount = 1f;
        totalScore = 0;
    }

    void Update()
    {
        //Increase the score by 5 every second
        timer += Time.deltaTime;
        if (timer >= delayAmount)
        {
            timer = 0f;
            setPlayerScore(1.25f);
        }
    }

    public float getScore()
    {
        return totalScore;
    }

    public void setPlayerScore(float val)
    {
        totalScore += (int)val;

        scoreGUI.text = "Score: " + totalScore.ToString();
    }
}
