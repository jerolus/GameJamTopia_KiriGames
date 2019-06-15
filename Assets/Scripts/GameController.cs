using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UIGameController controllerUI;
    public MapGenerator mapGenerator;
    public PlayerController player;

    private bool m_gameOver;

    private static GameController m_instance;

    private void Awake()
    {
        if (!m_instance)
        {
            m_instance = this;
        }
    }

    public static GameController GetInstance()
    {
        return m_instance;
    }

    public void GameOver()
    {
        m_gameOver = true;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
