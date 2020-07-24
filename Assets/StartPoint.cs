using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    // ###
    public string startPoint; //  맵이동후 케릭터 위치
    private Moving Player; //캐릭터 

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Moving>();
      

        if(startPoint == Player.currentMapName)
        {
     
            Player.transform.position = this.transform.position;
        }

    }
    // ###

}