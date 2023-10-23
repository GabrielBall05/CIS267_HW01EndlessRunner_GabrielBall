using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject highScoresMenu;
    public GameObject mainMenu;

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

        mainMenu.SetActive(false);
        highScoresMenu.SetActive(true);
    }
}
