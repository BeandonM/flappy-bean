using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 45f;
        for (int i = 1; i <= 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i;
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

            int score = Random.Range(0, 80);
            entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

            string name = "Bob";
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        }
    }
}
