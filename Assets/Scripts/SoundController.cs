using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Music music;
    [SerializeField] private UIMusicButton uIMusicButton;
    private bool isMusicOn = true;

    private void Start() {
        music = GetComponent<Music>();
    }

    public void ToggleMusic() {
        if(isMusicOn) {
            music.StopMusic();
            isMusicOn = false;
        }
        else {
            music.StartMusic();
            isMusicOn = true;
        }
        uIMusicButton.ToggleSoundIcon();
    }

    private void Update() {
        
    }


    private float SetVolume(float volume) { 
        music.SetVolume(volume);
        return music.GetVolume();
    }


}
