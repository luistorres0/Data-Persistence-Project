using System.IO;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;
    string playerName;
    string highScorePlayerName;
    int highScorePlayerScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScoreData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void savePlayerName(string name)
    {
        playerName = name;
    }

    public string getPlayerName()
    {
        return playerName;
    }

    [System.Serializable]
    public class SaveData
    {
        public string Name;
        public int Score;
    };

    public void SaveHighScoreData()
    {
        SaveData data = new SaveData();

        data.Name = highScorePlayerName;
        data.Score = highScorePlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.Name;
            highScorePlayerScore = data.Score;
        }
    }

    public string GetHighScoreName()
    {
        return highScorePlayerName;
    }

    public void SetHighScoreName(string name)
    {
        highScorePlayerName = name;
    }

    public int GetHighScore()
    {
        return highScorePlayerScore;
    }

    public void SetHighScore(int score)
    {
        highScorePlayerScore = score;
    }
}
