using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameController : MonoBehaviour
{
    public Text score;
    public Text pagesNumber;
    public GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void UpdateScore(float scoreGame)
    {
        int tempScore = (int)scoreGame;
        score.text = tempScore.ToString() + "m";
    }

    public void UpdatePagesNumber(int pagesNumbersGame)
    {
        pagesNumber.text = pagesNumbersGame.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGameButton()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartGameButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Runner", LoadSceneMode.Single);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
