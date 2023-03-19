using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using System.IO.Pipes;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public new string name;
    public int score;
    public List<string> namesSaved;
    public List<int> scoresSaved;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        LoadData();
        DontDestroyOnLoad(gameObject);
    }

   
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/scores.json";
        if (File.Exists(path))
        {
            namesSaved.Clear();
            scoresSaved.Clear();
            SaveData savedData = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            namesSaved = savedData.names.ToList();
            scoresSaved = savedData.scores.ToList();

        }
        else
        {
            for(int i= 0; i < 5; i++)
            {
                namesSaved[i] = "Anonymous";
                scoresSaved[i] = 0;
            }
        }  
    }
    public void Save()
    {
        int position = 0;
        foreach(int scoreSaved in scoresSaved)
        {
            if(score > scoreSaved)
            {
                position++;
            }
        }
        if(position > 0)
        {
            
            for(int i = scoresSaved.Count - 1; i > scoresSaved.Count - position; i --)
            {
                scoresSaved[i] = scoresSaved[i-1];
                namesSaved[i] = namesSaved[i-1];
            }
            scoresSaved[^position] = score;
            namesSaved[^position] = name;
        }

        string path = Application.persistentDataPath + "/scores.json";
        SaveData saveData = new();
        saveData.names = namesSaved.ToList();
        saveData.scores = scoresSaved.ToList();
        File.WriteAllText(path, JsonUtility.ToJson(saveData));
    }
    [System.Serializable]
    public class SaveData
    {
        public List<string> names;
        public List<int> scores;
    }


}
