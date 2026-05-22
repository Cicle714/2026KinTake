using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    [SerializeField]
    public int hp = 100;

    [SerializeField]
    private GameObject damageCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(FindObjectOfType<Player2>().transform.position);
    }

    public void OnDamage(int damage)
    {
        hp -= damage;
        GameObject canvas = Instantiate(damageCanvas, transform.position + transform.forward * 2f, Quaternion.identity);
        canvas.GetComponentInChildren<Text>().text = damage.ToString();
        canvas.transform.LookAt(FindObjectOfType<Player2>().transform.position);

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }


}
