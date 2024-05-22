using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking;

public class WebManager : MonoBehaviour
{
    // Start is called before the first frame update
    private string url = "https://flappy-bean-backend.onrender.com/api/highscores/addscore";
    private string dailyUrl = "https://flappy-bean-backend.onrender.com/api/highscores/day";
    private string monthUrl = "https://flappy-bean-backend.onrender.com/api/highscores/month";
    private string allTimeUrl = "https://flappy-bean-backend.onrender.com/api/highscores/alltime";
    private string contentType = "application/json";

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            getHighscores();
        }
    }
    public void postPlayerScore()
    {
        StartCoroutine(postScore(url));
    }
    public void getHighscores()
    {
        StartCoroutine(getScore("https://flappy-bean-backend.onrender.com/api/highscores/day"));
    }

    public void getDailyScores()
    {
        StartCoroutine(getScore(dailyUrl));
    }
    public void getMonthlyScores()
    {
        StartCoroutine(getScore(monthUrl));
    }
    public void getAllTimeScores()
    {
        StartCoroutine(getScore(allTimeUrl));
    }

    public IEnumerator postScore(string url)
    {
        ScoreData scoredata = new ScoreData(HighScoreManager.instance.getName(), ScoreManager.instance.getScore());
        using (UnityWebRequest request = UnityWebRequest.Post(url, scoredata.SaveToString(), contentType))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Request Error");
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
    public IEnumerator getScore(string url)
    {
        Debug.Log("Getting Highscores");
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Request Error");
            }
            else
            {

                Debug.Log(request.downloadHandler.text);
                List<HighscoreEntry> entries = JsonConvert.DeserializeObject<List<HighscoreEntry>>(request.downloadHandler.text);

                foreach (HighscoreEntry entry in entries)
                {
                    HighscoreTable.instance.createHighscoreEntryTransform(entry);
                }

            }
        }
    }
}