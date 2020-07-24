using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    private Moving thePlayer;
    private CharacterPivot thePivot;
    private Skill theSkill;
    
    public float kickRadius;        //공 차는 거리
    public float kickSpeed;         //공 속도
   
    private bool keyInput = true;   //공이 움직이는동안 다시 Kick이 실행되지 않도록 하기위함

    private Vector3 startPosition;  // 공이 움직이기 전에 위치를 기억해두었다가 이 위치로 돌아오게 해야함
    private Vector3 targetPosition; // 버튼을 눌렀을 때 공이 목표하는 지점

    private Vector2 distance;           // 플레이어와 목표하는 지점 사이의 거리
    private Vector2 ballDistance;       // 플레이어와 공 사이의 거리               
                                        // distance 보다 ballDistance가 커질때 까지 공을 움직일 예정


    private bool Attack = false;                // 공을 들고만 있을 때에는 적이 공격당하지 않아야 한다. 공격중엔 true, 들고만 있으면 flase;

    private WaitForSeconds yieldWaitTime = new WaitForSeconds(0.001f);

    private Vector3 originalScale;


    // Start is called before the first frame update
    void Start()
    {

        thePlayer = FindObjectOfType<Moving>();
        thePivot = FindObjectOfType<CharacterPivot>();
        theSkill = FindObjectOfType<Skill>();
        originalScale = this.transform.localScale;
    }

      
    // Update is called once per frame
    void Update()
    {

        if (keyInput)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Kick();
            }

            if (Input.GetKeyDown(KeyCode.Q) && theSkill.canUseSizeUp) 
            {
                theSkill.Skill_SizeUp();
            }


        }

    }

    public void Kick()
    {
        StartCoroutine(KickCorouotine());
    }

    IEnumerator KickCorouotine()
    {

        keyInput = false;       // 공이 움직이는동안에 컨트롤이 눌리지 않아야 함.
        thePivot.StopRotateBall();  //공이 움직이는 동안에 공의 각도가 변하지 않도록 해야함.
        Attack = true;      //공격 시작. OntriggerEnter2D 안의 코드들이 실행됨.

        startPosition = this.transform.localPosition;
        targetPosition = new Vector3(this.transform.localPosition.x + kickRadius, 0, this.transform.localPosition.z);

        float allTime = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < allTime) 
        {
            this.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime / allTime);
            elapsedTime += Time.deltaTime* kickSpeed;
            yield return yieldWaitTime;
        }

        elapsedTime = 0f;

        while (elapsedTime < allTime)
        {
            this.transform.localPosition = Vector3.Lerp(targetPosition, startPosition, elapsedTime / allTime);
            elapsedTime += Time.deltaTime * kickSpeed;
            yield return yieldWaitTime;
        }
        // Lerp를 사용할 때 너무 큰 KickRadius나 KickSpeed 값을 부여할 경우
        // 부드러운 움직임이아닌 프레임마다 끊겨 보이며 그 사이에 적이 있을 경우에는 OntriggerEnter2D가 발동되지 않을 수도 있음.


        if (this.transform.localScale == originalScale)
            startPosition = new Vector3(8, 0, 0);
        this.transform.localPosition = startPosition;

        keyInput = true;
        thePivot.CanRotateBall();
        Attack = true;      //공격 끝. OntriggerEnter2D 안의 코드들이 실행되지 않음.

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Attack)
        {
            if (collision.tag == "Enemy")
            {
                Debug.Log("!");
                // tag가 enemy인 Object를 만날 때
                // 오디오재생, 타격효과, 적체력감소 등등...
            }
        }

    }


   


}
