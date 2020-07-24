using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource musicsource;

    void Awake()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        musicsource = BackgroundMusic.GetComponent<AudioSource>();
    }
    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
    }
}
