using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;
    private void Start()
    {
        StartCoroutine(LoadScene());//LoadScene 실행
    }
    IEnumerator LoadScene() // 비동기로드(LoadSceneAsync)를 만들기 위해 코루틴 사용, LoadScene은 동기 로드
    {// 비동기 로드는 Scene을 불러올 때 멈추지 않고 다른 작업을 할 수 있다.
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Play"); // LoadSceneAsync가 AsyncOperation 반환
        operation.allowSceneActivation = false;

        while (!operation.isDone) // 로딩이 끝나서 isDone이 true가 될 때까지 반복
        {
            yield return null;
            if(progressbar.value<0.9f)//Slider의 value가 1이 될 때까지 계속 증가
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            if(progressbar.value>=1f)
            {
                loadtext.text = "press spacebar";
            }

            if(Input.GetKeyDown(KeyCode.Space)&&operation.progress>=0.9f)//operation.progress는 진행정도를 float형 0,1dmf qksghksgksek. 0은 진행중, 1은 진행완료
            {
                operation.allowSceneActivation = true;
            }
        }
    }
}
