using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text pagesNumber;
    public int pages;
    public List<GameObject> multiplierBooks = new List<GameObject>();
    public List<GameObject> invincibleBooks = new List<GameObject>();
    public List<GameObject> magnetBooks = new List<GameObject>();

    public void OnStartClick()
    {
        SceneManager.LoadScene("Runner", LoadSceneMode.Single);
    }

    public void OnLevelsClick()
    {
        pages = PlayerPrefs.GetInt("pagesNumber", 0);
        pagesNumber.text = pages.ToString();

        for (int i = 0; i < multiplierBooks.Count; i++)
        {
            if (i < PlayerPrefs.GetInt("levelMultiplier", 0))
            {
                multiplierBooks[i].SetActive(true);
            }
        }

        for (int i = 0; i < invincibleBooks.Count; i++)
        {
            if (i < PlayerPrefs.GetInt("levelInvincible", 0))
            {
                invincibleBooks[i].SetActive(true);
            }
        }

        for (int i = 0; i < magnetBooks.Count; i++)
        {
            if (i < PlayerPrefs.GetInt("levelMagnet", 0))
            {
                magnetBooks[i].SetActive(true);
            }
        }
                
    }

    public void OnOptionsClick()
    {
        
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnPowerUpButtonClick(string type)
    {
        if (pages >= 30)
        {
            pages -= 30;
            PlayerPrefs.SetInt("pagesNumber", pages);
            pagesNumber.text = pages.ToString();

            if (type == "Multiplier")
            {
                float lastValue = PlayerPrefs.GetFloat("timeMultiplier", 5);
                float newValue = lastValue + 1;
                PlayerPrefs.SetFloat("timeMultiplier", newValue);

                int lastLevel = PlayerPrefs.GetInt("levelMultiplier", 0);
                int newLevel = lastLevel + 1;

                PlayerPrefs.SetInt("levelMultiplier", newLevel);
                for (int i = 0; i < multiplierBooks.Count; i++)
                {
                    if (i < newLevel)
                    {
                        multiplierBooks[i].SetActive(true);
                    }
                }
            }
            
            if (type == "Invincible")
            {
                float lastValue = PlayerPrefs.GetFloat("timeInvincible", 5);
                float newValue = lastValue + 1;
                PlayerPrefs.SetFloat("timeInvincible", newValue);

                int lastLevel = PlayerPrefs.GetInt("levelInvincible", 0);
                int newLevel = lastLevel + 1;

                PlayerPrefs.SetInt("levelInvincible", newLevel);
                for (int i = 0; i < invincibleBooks.Count; i++)
                {
                    if (i < newLevel)
                    {
                        invincibleBooks[i].SetActive(true);
                    }
                }
            }
            
            if (type == "Magnet")
            {
                float lastValue = PlayerPrefs.GetFloat("timeMagnet", 5);
                float newValue = lastValue + 1;
                PlayerPrefs.SetFloat("timeMagnet", newValue);

                int lastLevel = PlayerPrefs.GetInt("levelMagnet", 0);
                int newLevel = lastLevel + 1;

                PlayerPrefs.SetInt("levelMagnet", newLevel);
                for (int i = 0; i < magnetBooks.Count; i++)
                {
                    if (i < newLevel)
                    {
                        magnetBooks[i].SetActive(true);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Not enought pages");        
        }
    }
}
