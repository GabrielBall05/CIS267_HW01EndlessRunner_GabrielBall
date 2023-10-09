using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private TMP_Text timeGUI;

    //Clock doesn't actually keep track of time, but GameManager does
    //This script is really just to update the timer in the top left cornerda
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
        timeGUI.text = "Time: " + gm.getTime().ToString("#.00") + "s";
    }
}
