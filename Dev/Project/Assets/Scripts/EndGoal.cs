using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGoal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject winText;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameTimer.Instance.enabled = false;
            collision.gameObject.SetActive(false);
            winText?.gameObject.SetActive(true);
            ScoreController.Instance.AddScore((int)(999 - GameTimer.Instance.time));
            int score = ScoreController.Instance.Score;
            bool newBest = PlayerScoreManager.Instance.RecordPlayerScore(score);
            var text = winText.GetComponentInChildren<TextMeshProUGUI>();
            text.text = $"You Win! Score: {ScoreController.Instance.Score.ToString("D6")}";
            if (newBest)
                text.text += "\n <size=60%>New Record!</size>";
            else
                text.text += $"\n <size=60%>Your Best: {PlayerScoreManager.Instance.RetrievePlayerBestScore().ToString("D6")}</size>";
            StartCoroutine(DelayedTransitionToMenu());
        }
    }
    
    public IEnumerator DelayedTransitionToMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        
    }
}
