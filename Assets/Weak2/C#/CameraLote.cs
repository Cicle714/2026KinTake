using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLote: MonoBehaviour
{
    [SerializeField] float sensitivity = 0.1f;

    float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            float mouseX = mouseDelta.x * sensitivity;
            float mouseY = mouseDelta.y * sensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.parent.Rotate(Vector3.up * mouseX);


        Debug.DrawRay(
   transform.position,
   transform.forward * 10f,
   Color.red
        );


    }
    public void OnClickLeft(InputAction.CallbackContext context)
    {
        Vector3 center = new Vector3(
            Screen.width / 2,
            Screen.height / 2,
            0
        );

        Ray ray = Camera.main.ScreenPointToRay(center);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
        {

            if (hit.collider.gameObject.GetComponent<Enemy2>())
            {
                hit.collider.gameObject.GetComponent<Enemy2>().OnDamage(25);
            }

            Debug.Log("Hit : " + hit.collider.name);
        }
    }
}
