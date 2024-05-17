using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;
    private string userInput;
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        if(ScoreManager.instance != null)
        {
            scoreText.text = "Score: " + ScoreManager.instance.getScore().ToString();
        }

    }

    public void readInput(string s)
    {
        userInput = s;
    }


    public string getName()
    {
        return userInput;
    }
}
