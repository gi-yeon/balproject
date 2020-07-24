using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform buttonScale;
    Vector3 defaultScale;
    public BTNType currentType;
    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.newStart:
                SceneManager.LoadScene("Loading");
                break;
            case BTNType.load:
                SceneManager.LoadScene("Loading");
                break;
            case BTNType.sound:
                SceneManager.LoadScene("Setting");
                break;
            case BTNType.quit:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit() // 어플리케이션 종료
#endif
                break;
            case BTNType.back:
                Debug.Log("back to the menu");
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale*1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
