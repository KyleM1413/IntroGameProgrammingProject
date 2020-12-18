using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    public int Score { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
 
    }
    public void AddScore(int score)
    {
        Score += score;
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
