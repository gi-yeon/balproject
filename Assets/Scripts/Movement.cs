using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 3f;
    public Animator animator;
    public bool isPlayerMoving = false;
    public Vector2 prevPosition;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        isPlayerMoving = false;

        // <-, ->, 입력했을 경우
        if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 moveHorizontal = new Vector3(Input.GetAxisRaw("Horizontal") * speed, 0f, 0f);
            transform.Translate(moveHorizontal);
            
            isPlayerMoving = true;
            prevPosition = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        // 위 방향키, 아래 방향키 입력했을 경우
        if (Input.GetAxisRaw("Vertical") > 0f || Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 moveVertical = new Vector3(0f, Input.GetAxisRaw("Vertical") * speed, 0f);
            transform.Translate(moveVertical);
            
            isPlayerMoving = true;
            prevPosition = new Vector2(0f, Input.GetAxisRaw("Horizontal"));
        }

        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetBool("isPlayerMoving", isPlayerMoving);
        animator.SetFloat("PrevMoveX", prevPosition.x);
        animator.SetFloat("PrevMoveY", prevPosition.y);
    }
}