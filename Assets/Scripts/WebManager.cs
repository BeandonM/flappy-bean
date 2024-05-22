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
                List<TestData> l = JsonConvert.DeserializeObject<List<TestData>>(request.downloadHandler.text);
                foreach(TestData test in l)
                {
                    Debug.Log(test.name);
                }
                //TestData d = JsonConvert.DeserializeObject<TestData>(request.downloadHandler.text);
                //TestData d = JS.FromJson<TestData>(request.downloadHandler.text);
                //Debug.Log(d.name);
            }
        }
    }
}


public class TestData
{
    public int id { get; set; }
    public string name { get; set; }
    public int score { get; set; }
    public DateTime score_date { get; set; }
    public string score_time { get; set; }
}