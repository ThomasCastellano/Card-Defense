//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;
//using UnityEngine.UI;


//public class HighscoreTable : MonoBehaviour
//{
//    [SerializeField]
//    private Transform entryContainer;
//    [SerializeField]
//    private Transform entryTemplate;
//    private List<HighscoreEntry> highscoreEntryList;
//    private List<Transform> highscoreEntryTransformList;

//    private void Awake()
//    {
        

//        entryTemplate.gameObject.SetActive(false);


//        AddHighscoreEntry(1000, "CMK");

//        string jsonString = PlayerPrefs.GetString("highscoreTable");
//        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);






//        for (int i = 0;i < highscores.highscoreEntryList.Count; i++)
//        {
//            for (int j = i+1; j < highscores.highscoreEntryList.Count; j++)
//            {
//                if (highscores.highscoreEntryList[j].score > highscores.
//                    highscoreEntryList[i].score)
//                {
//                    //Swap
//                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
//                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
//                    highscores.highscoreEntryList[j] = tmp;
//                }
//            }
//        }
//        ////////

     
    

//        if (highscores.highscoreEntryList.Count > 4)
//        {
//            for (int h = highscores.highscoreEntryList.Count; h > 4; h--)
//            {
//                highscores.highscoreEntryList.RemoveAt(4);
//            }
//        }

//        ////////


//        highscoreEntryTransformList = new List<Transform>();
//        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
//        {
//            CreateHighscoreEntryTransform(highscoreEntry, 
//                entryContainer, highscoreEntryTransformList);

//        }
     
        
//    }

//    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, 
//        Transform container, List<Transform> transformList)
//    {
//        float templateHeight = 30f;
//        Transform entryTransform = Instantiate(entryTemplate, container);
//        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
//        entryRectTransform.anchoredPosition = new Vector2(0, 
//            -templateHeight * transformList.Count);
//        entryTransform.gameObject.SetActive(true);

//        int rank = transformList.Count + 1;
//        string rankString;
//        switch (rank)
//        {
//            default:
//                rankString = "TH"; break;

//            case 1: rankString = "1ST"; break;
//            case 2: rankString = "2ND"; break;
//            case 3: rankString = "3RD"; break;

//        }

//        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

//        int score = highscoreEntry.score;

//        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

//        string name = highscoreEntry.name;

//       /* entryTransform.Find("nameText").GetComponent<Text>().text = name; */

//        transformList.Add(entryTransform);
//    }

//    private void AddHighscoreEntry(int score, string name)
//    {
//        //créer nbouvelles entrées
//        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, 
//            name = name };
        
//        string jsonString = PlayerPrefs.GetString("highscoreTable");
//        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

//        highscores.highscoreEntryList.Add(highscoreEntry);

//        string json = JsonUtility.ToJson(highscores);
//        PlayerPrefs.SetString("highscoreTable", json);
//        PlayerPrefs.Save();
//    }
//    private class Highscores
//    {
//        public List<HighscoreEntry> highscoreEntryList;
//    }
//    //represent a single highscore entry
//    [System.Serializable]
//    private class HighscoreEntry
//    {
//        public int score;
//        public string name;
//    }
//}
