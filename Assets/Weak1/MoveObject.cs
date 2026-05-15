using Unity.VisualScripting;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    [SerializeField]
        private Vector3 moveDistance; //ˆÚ“®”ÍˆÍ
    
    [SerializeField]
        private float moveSpeed; //ˆÚ“®‘¬“x

    enum MoveType
    {
        width,
        height,
        slanting,
        Circle
    }
    [SerializeField]
    MoveType moveType;
    [SerializeField]
    private bool revease; //ˆÚ“®‚Ì”½“]

    private Vector3 FirstPos;

    void Start()
    {
        FirstPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        myMoving();
    }

    void myMoving()
    {
        switch (moveType)
        {
            case MoveType.width:
                if(revease)
                    transform.position = FirstPos + -Vector3.right * Mathf.Sin(Time.time * moveSpeed) * moveDistance.x;
                else
                    transform.position = FirstPos + Vector3.right * Mathf.Sin(Time.time * moveSpeed) * moveDistance.x;
                break;
            case MoveType.height:
                if (revease)
                    transform.position = FirstPos + -Vector3.up * Mathf.Sin(Time.time * moveSpeed) * moveDistance.y;
                else
                    transform.position = FirstPos + Vector3.up * Mathf.Sin(Time.time * moveSpeed) * moveDistance.y;
                break;
            case MoveType.slanting:
                if (revease)
                    transform.position = FirstPos + -Vector3.right * Mathf.Sin(Time.time * moveSpeed) * moveDistance.x + Vector3.up * Mathf.Sin(Time.time * moveSpeed) * moveDistance.y;
                else
                    transform.position = FirstPos + Vector3.right * Mathf.Sin(Time.time * moveSpeed) * moveDistance.x + Vector3.up * Mathf.Sin(Time.time * moveSpeed) * moveDistance.y;
                break;
            case MoveType.Circle:
                if (revease)
                    transform.position = FirstPos + new Vector3(-Mathf.Cos(Time.time * moveSpeed), Mathf.Sin(Time.time * moveSpeed),0 ) * moveDistance.x;
                else
                    transform.position = FirstPos + new Vector3(Mathf.Cos(Time.time * moveSpeed),  Mathf.Sin(Time.time * moveSpeed),0) * moveDistance.x;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.parent = transform;
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }
}
