
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        StartMusic();
    }

    private void Update() {
        if (GameStateManager.instance.CurrentGameState == GameStateManager.GameState.GameOver) {
            StopMusic();
        }
    }

    public void StartMusic() {
        //audioSource.Play();
        SetVolume(100);
    }

    public void StopMusic() {
        //audioSource.Stop();
        SetVolume(0);
    }

    public void SetVolume(float volume) {
        audioSource.volume = volume;
    }

    public float GetVolume() {
        return audioSource.volume * 100;
    }
}
