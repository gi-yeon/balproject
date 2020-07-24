using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private BallScript theBall;

    public bool canUseSizeUp = true;   // 쿨타임 동안에는 flase 아니면 true
    public float duration;        // 지속시간
    public float sizeUp;          // 커지는 배수
    public float sizeUpCoolTime;        // 쿨타임 시간

    private void Start()
    {
        theBall = FindObjectOfType<BallScript>();
    }

    public void Skill_SizeUp()
    {
        StartCoroutine(SizeUp());

    }

    IEnumerator SizeUp()
    {
        canUseSizeUp = false;
        float distanceBallPlayer = 4f;
        Vector3 tempSize = theBall.transform.localScale;
        float alpha = (theBall.transform.localPosition.x - distanceBallPlayer) / tempSize.x;

        theBall.transform.localScale = new Vector3(tempSize.x * sizeUp, tempSize.y * sizeUp, tempSize.z);
        theBall.transform.localPosition = new Vector3(distanceBallPlayer + tempSize.x * sizeUp * alpha, 0, theBall.transform.localPosition.z);

        yield return new WaitForSeconds(duration);
        theBall.transform.localScale = tempSize;



        yield return new WaitForSeconds(sizeUpCoolTime);
        canUseSizeUp = true;
    }
}
