using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float speed; //ìÆÇ´ÇÃë¨Ç≥
    private int roteNum; //å¸Ç´
    public int PlayerHp; //ëÃóÕ


    private Vector2 moveInput = Vector2.zero; //Å@à⁄ìÆ


    [SerializeField]
    private GameObject Bullet; //é©êgÇ™îÚÇŒÇ∑íe

    Rigidbody rb;

    [SerializeField]
    private float JumpForce;

    /// <summary>
    ///InputSystemÇÃäàóp 
    /// </summary>
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;

    private bool IsPush = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerHp > 0)
        PlayerMove(); //à⁄ìÆ

    }
    /// <summary>
    /// å¸Ç´Ç∆à⁄ìÆèàóù
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
        PlayerRote();



        var move = transform.position + new Vector3(moveInput.x, 0f, moveInput.y) * speed * Time.deltaTime;
        transform.position = move;

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Debug.Log("Jumping");
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        
        if (context.canceled) {
            IsPush = false;
            return;
        }
        if (!context.started) return;
        if (!IsPush)
        {
            IsPush = true;
            Instantiate(Bullet, transform.position + transform.forward, transform.rotation);
        }
    }

    void PlayerRote()
    {
        switch (roteNum)
        {
            case 1:
                transform.rotation = Quaternion.Euler(Vector3.up * 0);
                break;
                case 2:
                transform.rotation = Quaternion.Euler(Vector3.up * 90);
                break;
                case 3:
                transform.rotation = Quaternion.Euler(Vector3.up * 45);
                break;
                case 4:
                transform.rotation = Quaternion.Euler(Vector3.up * 180);
                break;
            case 6:
                transform.rotation = Quaternion.Euler(Vector3.up * 135);
                break;
                case 7:
                transform.rotation = Quaternion.Euler(Vector3.up * 180);
                break;
                case 8:
                transform.rotation = Quaternion.Euler(Vector3.up * 270);
                break;
                case 9: 
                transform.rotation = Quaternion.Euler(Vector3.up * 315);
                break;
                case 11:
                transform.rotation = Quaternion.Euler(Vector3.up * 0);
                break;
                case 12:
                transform.rotation = Quaternion.Euler(Vector3.up * 225);
                break;
                case 13:
                transform.rotation = Quaternion.Euler(Vector3.up * 270);
                break;
                case 14:
                transform.rotation = Quaternion.Euler(Vector3.up * 180);
                break;

        }
        roteNum = 0;
    }

    
}
