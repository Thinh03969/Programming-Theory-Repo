using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    public string playerName;
    public int bestScore;
    public string bestPlayerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class BestPlayer
    {
        public string name;
        public int score;
    }

    public void SaveBestPlayer(int p_score)
    {
        BestPlayer bestPlayer = new BestPlayer();
        bestPlayer.score = p_score;
        bestPlayer.name = playerName;

        string json = JsonUtility.ToJson(bestPlayer);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlayer bestPlayer = JsonUtility.FromJson<BestPlayer>(json);

            bestScore = bestPlayer.score;
            bestPlayerName = bestPlayer.name;
        }
    }
}
