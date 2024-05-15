using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    private string userInput;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        if(Score.instance != null)
        {
            scoreText.text = Score.instance.getScore().ToString();
        }

    }

    public void readInput(string s)
    {
        userInput = s;
    }

    public void submitScore()
    {

    }
}
