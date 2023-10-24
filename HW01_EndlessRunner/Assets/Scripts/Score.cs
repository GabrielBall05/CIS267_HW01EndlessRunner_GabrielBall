using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    //This whole script is purely for the Score text and nothing else
    public TMP_Text scoreGUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        updateScoreGUI();
    }

    private void updateScoreGUI()
    {
        //Sets Score test to the total player score that GameManager keeps track of
        scoreGUI.text = "Score: " + GetComponent<GameManager>().getTotalPlayerScore().ToString();
    }
}