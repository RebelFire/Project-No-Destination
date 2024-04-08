using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI highScoreText;
    [SerializeField] private TMPro.TextMeshProUGUI timeText;
    [SerializeField] private PlayerScore playerScore;
    private float time = 0;

    private void Start() {
        UpdateHighScore(playerScore.GetHighScore());
    }


    public void UpdateHighScore(int score) { 
        highScoreText.text = "High Score: " + score;
        
    }

    public void UpdateTime(float time) {
        timeText.text = "Time: " + time;
    }

    public void UpdateScore(int score, bool highScore) {
        if(highScore) {
            UpdateHighScore(score);
        }
        scoreText.text = "Score: " + score;
    }
}
