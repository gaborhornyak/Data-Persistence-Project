using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static string PlayerName { get; set; }
    public static string BestPlayerName { get; set; }
    public static int BestPlayerScore { get; set; }

    private static string _SAVE_FILE;

    [System.Serializable]
    public class PersistentData
    {
        public string _playerName;
        public int _playerScore;
    }

    private void Awake()
    {
        // if we already have an instance then destroy actual newly created object
        if(Instance != null)
        {
            Object.Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // load savedata
        _SAVE_FILE = Application.persistentDataPath + "/savedata.json";
        LoadData();
    }

    public static void SaveData()
    {
        PersistentData persistentData = new PersistentData();
        persistentData._playerName = BestPlayerName;
        persistentData._playerScore = BestPlayerScore;

        string jsonData = JsonUtility.ToJson(persistentData);
        File.WriteAllText(_SAVE_FILE, jsonData);
    }

    public static void LoadData()
    {
        if (!File.Exists(_SAVE_FILE))
            return;

        string jsonData = File.ReadAllText(_SAVE_FILE);
        PersistentData persistentData = JsonUtility.FromJson<PersistentData>(jsonData);
        BestPlayerName = persistentData._playerName;
        BestPlayerScore = persistentData._playerScore;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }
}
