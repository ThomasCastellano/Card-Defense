using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreTableV2 : MonoBehaviour
{
    public static HighScoreTableV2 instance;

    public Transform entryContainer;
    public Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    public const int EntryCount = 4;

    public struct ScoreEntry
    {
        public string name;
        public float score;

        public ScoreEntry(string name, float score)
        {
            this.name = name;
            this.score = score;
        }
    }

    private static List<ScoreEntry> s_Entries;

    private static List<ScoreEntry> Entries
    {
        get
        {
            if (s_Entries == null)
            {
                s_Entries = new List<ScoreEntry>();
                LoadScores();
            }
            return s_Entries;
        }
    }

    private const string PlayerPrefsBaseKey = "leaderboard";

    private void Awake()
    {
        instance = this;

        //Reset();
        //Record("Vincent", 100);
        Scores();
    }

    public void Scores()
    {
        for (int i = 1; i < entryContainer.childCount; i++)
        {
            Destroy(entryContainer.GetChild(i).gameObject);
        }
        highscoreEntryTransformList = new List<Transform>();
        for (int i = 0; i < 10 && i < Entries.Count; i++)
        {
            ScoreEntry highscoreEntry = Entries[i];
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private static void SortScores()
    {
        s_Entries.Sort((a, b) => b.score.CompareTo(a.score));
    }

    private static void LoadScores()
    {
        s_Entries.Clear();

        for (int i = 0; i < EntryCount; ++i)
        {
            ScoreEntry entry;
            entry.name = PlayerPrefs.GetString(PlayerPrefsBaseKey + "[" + i + "].name", "");
            entry.score = PlayerPrefs.GetFloat(PlayerPrefsBaseKey + "[" + i + "].score", 0);
            s_Entries.Add(entry);
        }

        SortScores();
    }

    private static void Reset()
    {
        PlayerPrefs.DeleteAll();
    }

    private static void SaveScores()
    {
        for (int i = 0; i < EntryCount; ++i)
        {
            var entry = s_Entries[i];
            PlayerPrefs.SetString(PlayerPrefsBaseKey + "[" + i + "].name", entry.name);
            PlayerPrefs.SetFloat(PlayerPrefsBaseKey + "[" + i + "].score", entry.score);
        }
    }

    public static ScoreEntry GetEntry(int index)
    {
        return Entries[index];
    }

    public void Record(string name, float score)
    {
        Entries.Add(new ScoreEntry(name, score));
        SortScores();
        Entries.RemoveAt(Entries.Count - 1);
        SaveScores();
    }
    private void CreateHighScoreEntryTransform(ScoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 115f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        float score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString("0.00") + " s";

        //string name = highscoreEntry.name;

        //entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;


       /* if (rank == 1)
        {
            entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().color = Color.green;
        }*/
        transformList.Add(entryTransform);

    }
}

    /*public Transform entryContainer;
    public Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    { 
        //AddHighscoreEntry(10000, "CMK");

        string json = JsonUtility.ToJson(new List<HighscoreEntry>() { new HighscoreEntry { score = 1000, name = "Vincent"} });
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        //Debug.Log(jsonString);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        //foreach(HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        for (int i = 0; i<10 && i < highscores.highscoreEntryList.Count; i++)
        {
            HighscoreEntry highscoreEntry = highscores.highscoreEntryList[i];
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.name;

        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        *//*entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        if(rank == 1)
        {
            entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().color = Color.green;
        }*//*
        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name};
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        // Debug.Log(highscores.highscoreEntryList);
        highscores.highscoreEntryList.Add(highscoreEntry);

        //TODO: Sort here
        //highscores.highscoreEntryList.RemoveRange(14, highscores.highscoreEntryList.Count - 14);

        string json = JsonUtility.ToJson(highscoreEntry);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
        public Highscores()
        {
            highscoreEntryList = new List<HighscoreEntry>();
        }
    }

    [System.Serializable]
    public class HighscoreEntry
    {
        public int score;
        public string name;

       *//* public HighscoreEntry(int score, string name)
        {
            this.score = score;
            this.name = name;
        }*//*
    }*/
