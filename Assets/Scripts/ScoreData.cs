using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData
{
    public string name;
    public int score;
    public ScoreData()
    {
        name = string.Empty;
        score = 0;
    }
    public ScoreData(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}
