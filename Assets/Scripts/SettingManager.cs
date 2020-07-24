using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource musicsource;    // 배경음악이 저장될 변수
    public AudioSource btnsource;   // 버튼 효과음이 저장될 변수
    public Scrollbar sliderA;
    public Scrollbar sliderB;

    public void SetMusicVolume(float volume)    // 배경음악 소리 조절
    {
        musicsource.volume = volume;
    }
    public void SetButtonVolume(float volume)   // 이펙트(버튼 등) 소리 조절
    {
        btnsource.volume = volume;
    }
    public void BtnaOnClick()       // 버튼 클릭 시
    {
        btnsource.Play();
        PlayerPrefs.SetFloat("SliderA", sliderA.value);
        PlayerPrefs.SetFloat("SliderB", sliderB.value);
        Destroy(btnsource.gameObject, 2f);
        DontDestroyOnLoad(btnsource.gameObject);
        SceneManager.LoadScene("Main");
    }
    void Awake()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic");   // 재생중인 배경음악의 오브젝트를 찾아서 BackgroundMusic에 저장
        musicsource = BackgroundMusic.GetComponent<AudioSource>();  // 배경음악 오브젝트의 오디오소스를 musicsource에 저장

        if (PlayerPrefs.HasKey("SliderA"))
        {
            sliderA.value = PlayerPrefs.GetFloat("SliderA");
            sliderB.value = PlayerPrefs.GetFloat("SliderB");
            Debug.Log("키 존재");
        }
    }
}
