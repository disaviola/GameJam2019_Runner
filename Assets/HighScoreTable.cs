using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreTable : MonoBehaviour
{


    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    [SerializeField] private InputField inputField;


    private int rank = 0;
    private string rankString;
    private int score;
    private string name;

    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    MySceneManager sceneManager;
    private void Awake()
    {

        entryTemplate.gameObject.SetActive(false);


    }


    public void StartHighscoreTable()
    {


        sceneManager = GetComponent<MySceneManager>();

        AddHighscoreEntry(1313131, "asdasd");
        //AddHighscoreEntry(sceneManager.points, inputField.text);

        //AddHighscoreEntry(1099898, "CMK");


        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);



        //sort highScore
        for (int i = 0; i < highscores.highScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highScoreEntryList.Count; j++)
            {
                if (highscores.highScoreEntryList[j].score > highscores.highScoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscores.highScoreEntryList[i];
                    highscores.highScoreEntryList[i] = highscores.highScoreEntryList[j];
                    highscores.highScoreEntryList[j] = tmp;
                }
            }
        }
        //Create entry transform list
        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highscores.highScoreEntryList)
        {
            CreateHighScoreEntryTrans(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }

    }

    private void CreateHighScoreEntryTrans(HighScoreEntry highScoreEntry, Transform container, List<Transform> transfromList)
    {

        float temphight = 40;

        Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -temphight * transfromList.Count);
        entryTransform.gameObject.SetActive(true);


        rank = transfromList.Count + 1;
        switch (rank)
        {
            default:
                rankString = "Nb. " + rank; break;
        }

        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

        name = highScoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        score = highScoreEntry.score;

        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();



        transfromList.Add(entryTransform);
    }


    private void AddHighscoreEntry(int score, string name)
    {
        // create Highscore
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        //load saved scores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //add new entry
        highscores.highScoreEntryList.Add(highScoreEntry);
        //save updated
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }


    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }





}
