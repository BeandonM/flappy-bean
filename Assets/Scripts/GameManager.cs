using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1.0f;
    }
    public void gameOver()
    {
        gameCanvas.SetActive(true);

        Time.timeScale = 0f;
    }

    public void restartGame()
    {
        ScoreManager.instance.restartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void submitHighScore()
    {
        gameCanvas.SetActive(false);
        SceneManager.LoadScene("ScoreScene", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }
}
