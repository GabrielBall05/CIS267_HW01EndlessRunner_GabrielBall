using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private float time;
    private TMP_Text timeGUI;

    public GameObject gameManager;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
        timeGUI = GetComponent<TMP_Text>();
        time = 0;
        updateTimeGUI();
    }

    // Update is called once per frame
    void Update()
    {
        timerTick();
    }

    public float getTime()
    {
        return time;
    }

    public void setTime(float t)
    {
        time = t;
    }

    public void timerTick()
    {
        time += Time.deltaTime;
        updateTimeGUI();
    }

    public void updateTimeGUI()
    {
        //#.00 rounds float to 2 decimal places
        timeGUI.text = "Time: " + time.ToString("#.00") + "s";
    }
}
