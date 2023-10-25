using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    //This script is only for the timer text at the top left and nothing else
    private TMP_Text timeGUI;

    //GameManger keeps track of time, not this script
    public GameObject GameManager;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetComponent<GameManager>();
        timeGUI = GetComponent<TMP_Text>();
        updateTimeGUI();
    }

    // Update is called once per frame
    void Update()
    {
        updateTimeGUI();
    }

    public void updateTimeGUI()
    {
        //#.00 rounds float to 2 decimal places
        timeGUI.text = "Time: " + gm.getTime().ToString("#") + "s";
    }
}