using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private int score;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        currentScoreText.text = score.ToString();

        highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

    }

    private void updateHighScore()
    {
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void updateScore()
    {
        score++;
        currentScoreText.text = score.ToString();
        updateHighScore();
    }
}
