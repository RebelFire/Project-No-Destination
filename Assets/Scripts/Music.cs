
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void StartMusic() {
        audioSource.Play();
    }

    public void StopMusic() {
        audioSource.Stop();
    }

    public void SetVolume(float volume) {
        audioSource.volume = volume;
    }

    public float GetVolume() {
        return audioSource.volume * 100;
    }
}
