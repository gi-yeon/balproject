using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 3f;
    public Animator animator;
    public bool isPlayerMoving = false;
    public Vector2 prevPosition;
    public Rigidbody2D playerRigidbody;
    private float tmpSpeed;

    public Vector2 arrow;

    float inputX;
    float inputY;

    private float tmpInputX;
    private float tmpInputY;

    private float incX;
    private float incY;

    private float lastInputX = 0;
    private float lastInputY = 0;


    bool bothArrow = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        tmpSpeed = speed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        //isPlayerMoving = false;

        isPlayerMoving = false;


        tmpInputX = Input.GetAxis("Horizontal");
        tmpInputY = Input.GetAxis("Vertical");
        if (tmpInputX != 0 && tmpInputY != 0 && bothArrow)
        {
            speed = speed / Mathf.Sqrt(2);
            bothArrow = false;
        }
        else
        {
            speed = tmpSpeed;
            bothArrow = true;
        }



        if (tmpInputX != 0)
        {
            incX = Mathf.Abs(tmpInputX) - Mathf.Abs(lastInputX);
            if (incX >= 0)
            {
                isPlayerMoving = true;
                prevPosition = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                inputX = tmpInputX / Mathf.Abs(tmpInputX);
            }
            else if (incX < 0)
            {
                inputX = 0;
            }

        }

        if (tmpInputY != 0)
        {
            incY = Mathf.Abs(tmpInputY) - Mathf.Abs(lastInputY);
            if (incY >= 0)
            {
                isPlayerMoving = true;
                inputY = tmpInputY / Mathf.Abs(tmpInputY);
                prevPosition = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            else if (incY < 0)
            {
                inputY = 0;
            }

        }

        if (tmpInputX == 0 && tmpInputY == 0)
        {
            inputX = 0;
            inputY = 0;
        }

        Vector2 movement = new Vector2(inputX, inputY);

        movement = movement * speed;

        playerRigidbody.velocity = movement;

        lastInputX = tmpInputX;
        lastInputY = tmpInputY;

        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetBool("isPlayerMoving", isPlayerMoving);
        animator.SetFloat("PrevMoveX", prevPosition.x);
        animator.SetFloat("PrevMoveY", prevPosition.y);


        arrow = new Vector2(inputX, inputY);

    }
}