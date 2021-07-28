using System;
using System.IO;
using UnityEngine;

public class DataTransferManager : MonoBehaviour
{
    public static DataTransferManager Instance;
    
    public string Nickname { get; set; }
    public int Score { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    
    public void Save()
    {
        SaveData data = new SaveData();
        data.nick = Nickname;
        data.score = Score;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Nickname = data.nick;
            Score = data.score;
        }
    }

    public void OnDestroy()
    {
        Save();
    }

    [System.Serializable]
    class SaveData
    {
        public string nick;
        public int score;
    }
}
