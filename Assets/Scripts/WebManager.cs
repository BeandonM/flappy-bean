using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebManager : MonoBehaviour
{
    // Start is called before the first frame update
    private string url = "https://flappy-bean-backend.onrender.com/api/highscores/addscore";
    private string contentType = "application/json";

    public void postPlayerScore()
    {
        StartCoroutine(postScore(url));
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
}
