using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class MainManager : MonoBehaviour
{

    [System.Serializable]
    class SaveData{
        public string name;
        public int score;
    }
    public static MainManager Instance{ get; private set;}

    
    private SaveData data;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        data = new SaveData();
        DontDestroyOnLoad(gameObject);
    }

    // saves and returns true if a higher score is saved else doesnt save and returns false
    public bool SaveScore(int score)
    {
        SaveData sdata = new SaveData();
        sdata.name = data.name;
        sdata.score = score;
        int preHighScore = LoadScore();
        Debug.Log("is this working savescore?" + preHighScore);
        if (sdata.score > preHighScore)
        {

            Debug.Log("previous highest score + " + preHighScore);
            string path = Application.persistentDataPath + "/savefile.json";

            string json = JsonUtility.ToJson(sdata);
            File.WriteAllText(path, json);
            return true;
        }
        return false;
    }
    public int LoadScore()
    {
        
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            Debug.Log(File.Exists(path));
            string json = File.ReadAllText(path);
            Debug.Log(json);
            SaveData ldata = JsonUtility.FromJson<SaveData>(json);
            data.name = ldata.name;
            return ldata.score;
        }
        
        return 0;
    }

    public void SetName(string n)
    {
        Debug.Log(n);
        data.name = n;
        Debug.Log(data.name);
    }

    public string GetName()
    {
        return data.name;
    }
}
