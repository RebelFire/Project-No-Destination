using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Music music;


    private void Start() {
        music.StartMusic();
    }

    private float SetVolume(float volume) { 
        music.SetVolume(volume);
        return music.GetVolume();
    }


}
