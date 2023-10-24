using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject gameOverMenu;
    public GameObject highScoresMenu;
    private GameManager gm;
    private bool highScoresButtonClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.getGameOver() && !highScoresButtonClicked)
        {
            showGameOverMenu();
        }
    }

    public void showGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void restartGameButtonClick()
    {
        gm.setGameOver(false);
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }

    public void viewHighScoresButtonClick()
    {
        highScoresButtonClicked = true;
        gameOverMenu.SetActive(false);
        highScoresMenu.SetActive(true);
    }

    public void exitGameButtonClick()
    {
        Application.Quit();
    }
}