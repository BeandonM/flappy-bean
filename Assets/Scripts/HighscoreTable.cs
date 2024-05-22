using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry() {score = 10, name = "Bob"},
            new HighscoreEntry() {score = 11, name = "Bob"},
            new HighscoreEntry() {score = 12, name = "Bob"},
            new HighscoreEntry() {score = 13, name = "Bob"},
            new HighscoreEntry() {score = 14, name = "Bob"},
            new HighscoreEntry() {score = 15, name = "Bob"},
            new HighscoreEntry() {score = 16, name = "Bob"},
            new HighscoreEntry() {score = 17, name = "Bob"},
            new HighscoreEntry() {score = 18, name = "Bob"},
            new HighscoreEntry() {score = 19, name = "Bob"},
        };
        highscoreEntryTransformList = new List<Transform>();
        foreach( HighscoreEntry entry in highscoreEntryList)
        {
            createHighscoreEntryTransform(entry, entryContainer, highscoreEntryTransformList);
        }
    }
    private void createHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList )
    {
        float templateHeight = 45f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count;
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
    private class HighscoreEntry
    {
        public int id;
        public string name;
        public int score;
        public string score_date;
        public string score_time;
    }
}
