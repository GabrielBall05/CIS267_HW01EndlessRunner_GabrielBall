using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void playGameButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void exitGameButtonClick()
    {
        Application.Quit();
    }

    public void viewHighScoresButtonClick()
    {
        //view high scores
    }
}
