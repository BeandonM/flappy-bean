using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    //private int score;

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
        //DontDestroyOnLoad(gameObject);
        currentScoreText.text = ScoreManager.instance.getScore().ToString();///score.ToString();

        highScoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

    }

    public void updateHighScore()
    {
        int score = ScoreManager.instance.getScore();
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void updateScore()
    {
        int score = ScoreManager.instance.getScore();
        currentScoreText.text = score.ToString();
        updateHighScore();
    }
}
