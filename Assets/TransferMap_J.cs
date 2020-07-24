using UnityEngine;
using UnityEngine.SceneManagement; //Scene 매니저 라이브러리 추가


public class TransferMap_J : MonoBehaviour
{
    public string TransferMap; // 이동할 맵  

    private Moving Player; // 케릭터


    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Moving>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "정지")
        {
            Player.currentMapName = TransferMap;
            SceneManager.LoadScene(TransferMap);
        }
    }
}
