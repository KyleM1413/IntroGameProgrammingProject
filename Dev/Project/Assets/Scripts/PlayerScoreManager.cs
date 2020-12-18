using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreManager : MonoBehaviour
{
    public int levelId = -1;
    public static PlayerScoreManager Instance;
    // Start is called before the first frame update
    public static string ScoreKeyForLevelID(int id)
    {
        return $"Level_{id}_score";
    }
    void Start()
    {
        
    }
    //Return True if Score was a new Best
    public bool RecordPlayerScore(int score)
    {
        string key = ScoreKeyForLevelID(levelId);
        int playerScore = PlayerPrefs.GetInt(key, 0);
        if(score > playerScore)
        {
            PlayerPrefs.SetInt(key, score);
            return true;
        }
        return false;
    }
    public int RetrievePlayerBestScore()
    {
        return PlayerPrefs.GetInt(ScoreKeyForLevelID(levelId), 0);
    }
    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
