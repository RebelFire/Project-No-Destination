using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShrinkUI : MonoBehaviour {

    private Image image;
    [SerializeField] private TextMeshProUGUI text;

    private void Start() {
        image = gameObject.GetComponent<Image>();
    }

    public void ChangeImageRadial(float value, float time) {
        string timeText = " ";
        if(time > 0.2f) {
            timeText = time.ToString("F0");
        }
        text.text = timeText;
        image.fillAmount = value;
    }

}
