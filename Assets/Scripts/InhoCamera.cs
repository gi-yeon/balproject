using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhoCamera : MonoBehaviour
{

    Moving player;

    Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Moving>();
    }

    // Update is called once per frame
    void Update()
    {
        vector = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = vector;
    }
}