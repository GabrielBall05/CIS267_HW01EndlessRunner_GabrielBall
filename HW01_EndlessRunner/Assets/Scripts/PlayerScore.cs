using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
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
        scoreGUI.text = "Score: " + GetComponent<GameManager>().getTotalPlayerScore().ToString();
    }
}
