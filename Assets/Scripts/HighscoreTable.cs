using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    public static HighscoreTable instance;
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>();

        highscoreEntryTransformList = new List<Transform>();
        int counter = 0;
        int maxcounter = 30;
        foreach( HighscoreEntry entry in highscoreEntryList)
        {
            if(counter < maxcounter)
            {
                createHighscoreEntryTransform(entry);
                counter++;
            }
            else
            {
                break;
            }
        }
    }
    public void clearHighscoreTable()
    {
        highscoreEntryList.Clear();
        highscoreEntryTransformList.Clear();
        foreach (Transform entryObj in entryContainer)
        {
            if (entryObj.GetInstanceID() != entryTemplate.GetInstanceID())
            {
                Destroy(entryObj.gameObject);
            }
        }
    }
    public void createHighscoreEntryTransform(HighscoreEntry highscoreEntry)
    {
        float templateHeight = 37f;
        Transform container = entryContainer;
        List<Transform> transformList = highscoreEntryTransformList;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        int rank = transformList.Count + 1;
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * rank);
        entryTransform.gameObject.SetActive(true);


        string rankString;
        switch (rank)
        {
            default:
                {
                    rankString = rank + "TH";
                    break;
                }
            case 1:
                {
                    rankString = "1ST";
                    break;
                }
            case 2:
                {
                    rankString = "2ND";
                    break;
                }
            case 3:
                {
                    rankString = "3RD";
                    break;
                }
        }
        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);
    }
}
