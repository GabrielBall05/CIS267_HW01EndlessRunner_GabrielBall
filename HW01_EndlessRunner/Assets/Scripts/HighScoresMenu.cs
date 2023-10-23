using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoresMenu : MonoBehaviour
{
    private List<int> highScores;
    public TMP_Text scoresGUI;
    public GameObject highScoresMenu;
    public GameObject gameOverMenu;
    public GameObject GameManager;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetComponent<GameManager>();
        highScores = gm.GetComponent<SaveData>().loadData();

        //scoresGUI.text = "scorestest";
        scoresGUI.text = "1st: " + highScores[4] + "\n" + "2nd: " + highScores[3] + "\n" + "3rd: " + highScores[2] + "\n" + "4th: " + highScores[1] + "\n" + "5th: " + highScores[0];
    }

    private void Update()
    {
        gm = GameManager.GetComponent<GameManager>();
        highScores = gm.GetComponent<SaveData>().loadData();

        //scoresGUI.text = "scorestest";
        scoresGUI.text = "1st: " + highScores[4] + "\n" + "2nd: " + highScores[3] + "\n" + "3rd: " + highScores[2] + "\n" + "4th: " + highScores[1] + "\n" + "5th: " + highScores[0];
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
