using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backmusic;

    void Awake()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        backmusic = BackgroundMusic.GetComponent<AudioSource>();

        DontDestroyOnLoad(BackgroundMusic);

    }
}
