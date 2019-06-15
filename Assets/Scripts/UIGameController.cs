using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameController : MonoBehaviour
{
    public Text score;
    public Text pagesNumber;

    public void UpdateScore(float scoreGame)
    {
        int tempScore = (int)scoreGame;
        score.text = tempScore.ToString() + "m";
    }

    public void UpdatePagesNumber(int pagesNumbersGame)
    {
        pagesNumber.text = pagesNumbersGame.ToString();
    }
}
