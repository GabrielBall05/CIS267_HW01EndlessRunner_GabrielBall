using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoresMenu : MonoBehaviour
{
    private List<int> highScores; //Have an ArrayList
    public TMP_Text scoresGUI;
    public GameObject highScoresMenu;
    public GameObject gameOverMenu;
    public GameObject GameManager;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetComponent<GameManager>();
        //Copy the arraylist from the .sc file to this arraylist
        highScores = gm.GetComponent<SaveData>().loadData();

        //Show the rankings with a new line after each one
        //The list should already have been sorted before it was stored in the file from GameManager on game end
        scoresGUI.text = "1st: " + highScores[4] + "\n" + "2nd: " + highScores[3] + "\n" + "3rd: " + highScores[2] + "\n" + "4th: " + highScores[1] + "\n" + "5th: " + highScores[0];
    }

    private void Update()
    {
        //===
        //I needed to keep filling in the data because it would only show the most recent high score 1 game afterwards
        highScores = gm.GetComponent<SaveData>().loadData();
        scoresGUI.text = "1st: " + highScores[4] + "\n" + "2nd: " + highScores[3] + "\n" + "3rd: " + highScores[2] + "\n" + "4th: " + highScores[1] + "\n" + "5th: " + highScores[0];
        //===
    }

    public void backButtonCLick()
    {
        highScoresMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void playButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void exitButtonClicked()
    {
        Application.Quit();
    }
}