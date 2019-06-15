using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UIGameController controllerUI;
    public MapGenerator mapGenerator;
    public PlayerController player;

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
}
