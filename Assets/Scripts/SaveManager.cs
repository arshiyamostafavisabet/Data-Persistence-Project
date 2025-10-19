using UnityEngine;
using System.IO;
using TMPro;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;

    public string playerName;
    public int highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefiles.json", json);

    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefiles.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            playerName = data.playerName;
        }
    }

}
