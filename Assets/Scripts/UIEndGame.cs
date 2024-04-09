using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIEndGame : MonoBehaviour {

    [SerializeField] private GameObject background;

    [SerializeField] private GameObject stars;
    [SerializeField] private Image[] starImages;
    [SerializeField] private Sprite[] starSprites;

    [SerializeField] private GameObject highScore;
    [SerializeField] private GameObject timeGO;
    [SerializeField] private GameObject scoreGO;
    [SerializeField] private GameObject restartButton;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Start() {
        starImages[0].sprite = starSprites[0];
        starImages[1].sprite = starSprites[0];
        starImages[2].sprite = starSprites[0];
    }

    public void EnableGUI(bool isHighScore, int score, int time) {
        background.SetActive(true);
        stars.SetActive(true);
        scoreGO.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
        timeGO.SetActive(true);
        timeText.text = "Time: "+time.ToString();
        LightStars(score);
        if (isHighScore) {
            highScore.SetActive(true);
        }
        restartButton.SetActive(true);
    }

    private void LightStars(int score) {
        if(score < 15) {

        }
        else if (score < 25) {
            starImages[0].sprite = starSprites[1];
        }
        else if (score < 50) {
            starImages[0].sprite = starSprites[1];
            starImages[1].sprite = starSprites[1];
        }
        else{
            starImages[0].sprite = starSprites[1];
            starImages[1].sprite = starSprites[1];
            starImages[2].sprite = starSprites[1];
        }
    }


}