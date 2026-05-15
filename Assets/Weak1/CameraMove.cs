using UnityEngine;

public class CameraMove : MonoBehaviour
{

    Player1 player;
    [SerializeField]
    private Vector3 cameraOffset; //カメラとプレイヤーの距離

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<Player1>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z) + cameraOffset;
    }
}
