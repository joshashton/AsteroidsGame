using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePrefManager : MonoBehaviour
{
    //public TextMeshProUGUI highScoreText;
    const string ScoreKey = "score";
    //public GameManager manager;
    //public int currentScore;

    void OnApplicationQuit()
    {
        //SavePrefs();
    }

    //manager.GetScore()
    public void SavePrefs(int score)
    {
        Debug.Log(PlayerPrefs.GetInt("score"));
        var currentScore = PlayerPrefs.GetInt(ScoreKey, 0);
        if (score >= currentScore)
        {
            PlayerPrefs.SetInt(ScoreKey, score);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt("score"));

        } else
        {
            return;
        }
    }

}
