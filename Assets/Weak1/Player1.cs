using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{

    [SerializeField]
    private float speed; //動きの速さ
    private int roteNum; //向き
    public int PlayerHp; //体力


    private Vector2 moveInput = Vector2.zero; //　移動

    [SerializeField]
    Text HpText; //体力表示用テキスト
    [SerializeField]
    Text GameOverText;


    [SerializeField]
    private GameObject Bullet; //自身が飛ばす弾

    private GameObject ReSpwnObject;

    Rigidbody rb;

    [SerializeField]
    private float JumpForce;

    /// <summary>
    ///InputSystemの活用 
    /// </summary>
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;

    private bool IsPush = false;

    private bool IsGround = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        for (int i = 0; i < PlayerHp; i++)
        {
            HpText.text += "♥";
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerHp >= 1)
        PlayerMove(); //移動

        if (transform.position.y < -10)
        {
            if (PlayerHp >= 1)
            {
                PlayerHp -= 1;
                HpText.text = HpText.text.Substring(0, HpText.text.Length - 1);
                if (PlayerHp <= 0)
                {
                    GameOverText.gameObject.SetActive(true);
                }
                else
                {

                    transform.position = ReSpwnObject.transform.position + Vector3.up * 1.5f;
                }
            }

        }


    }
    /// <summary>
    /// 向きと移動処理
    /// </summary>
    void PlayerMove()
    {
        if (moveInput.y > 0)
        {
            roteNum += 1;
        }
        if (moveInput.x > 0)
        {
            roteNum += 2;

        }
        if (moveInput.y < 0)
        {
            roteNum += 4;
        }
        if (moveInput.x < 0)
        {
            roteNum += 8;
        }



        var move = transform.position + new Vector3(moveInput.x, 0f, 0) * speed * Time.deltaTime;
        transform.position = move;

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if(IsGround)
        rb.AddForce(Vector3.up * JumpForce);
    }
    public void OnContinue(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (PlayerHp <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ReSpwnObject = collision.gameObject;
            IsGround = false;
        }
    }
   

}
