using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMusicButton : MonoBehaviour {


    [SerializeField] private Sprite soundOnIcon;
    [SerializeField] private Sprite soundOffIcon;
    [SerializeField] private Image image;
    private bool isSoundOn = true;



    public void ToggleSoundIcon() {
        if (isSoundOn) {
            image.sprite = soundOffIcon;
            isSoundOn = false;
        }
        else {
            image.sprite = soundOnIcon;
            isSoundOn = true;
        }
    }


}