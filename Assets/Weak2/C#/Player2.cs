using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    public int Hp;
    [SerializeField]
    private Text HpText;
    [SerializeField]
    private Text GameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitDamage(int damage)
    {
        Hp -= damage;
        HpText.text = HpText.text.Substring(0, HpText.text.Length - 1);
        if(Hp <= 0)
        {
            GameOverText.gameObject.SetActive(true);
            GetComponentInChildren<CameraLote>().enabled = false;
        }
    }
    public void Retry(InputAction.CallbackContext context)
    {

        if (!context.started) return;

       if(Hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        

    }

}
