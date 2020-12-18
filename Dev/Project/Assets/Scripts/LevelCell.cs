using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelCell : MonoBehaviour
{
    public TextMeshProUGUI ButtonText;
    public Button playButton;
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI ScoreText;
    public Image levelImage;
    public int levelID = 0;
    void Start()
    {
        playButton.onClick.AddListener(PlayButtonPressed);
        TitleText.text = $"Level {levelID}";
        int playerScore = PlayerPrefs.GetInt($"Level_{levelID}_score", 0);
        ScoreText.text = $"Best Score: { playerScore.ToString("D6")}";
        UpdatePlayButtonState();
    }
    void UpdatePlayButtonState()
    {
        bool playable = PlayerPrefs.GetInt($"level_cleared_{levelID - 1}", levelID == 1 ? 1 : 0) == 1 ? true : false;
        if(playable)
        {
            ButtonText.text = "Play";
            playButton.interactable = true;
            levelImage.sprite = Resources.Load<Sprite>($"Textures/level_{levelID}");
        }
        else
        {
            ButtonText.text = $"Clear Level {levelID - 1}";
            playButton.interactable = false;
            levelImage.sprite = Resources.Load<Sprite>($"Textures/level_locked");

        }
    }
    void PlayButtonPressed()
    {
        SceneManager.LoadScene(levelID);
    }
    void Update()
    {
        
    }
}
