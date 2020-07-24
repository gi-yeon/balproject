using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("Think", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);

        Invoke("Think", 1);
    }
}
