using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;

    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPosition;

    private Moving thePlayer;

    private Camera theCamera;

    private void Awake()
    {

        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            thePlayer = FindObjectOfType<Moving>();
            this.transform.position = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y, this.transform.position.z);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        theCamera = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);

        }
    }



}
