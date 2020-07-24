using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingmain : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("Loading");
    }
}