using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    [SerializeField]
    public int hp = 100;
    [SerializeField]
    private float speed;

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
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void OnDamage(int damage)
    {
        hp -= damage;
        GameObject canvas = Instantiate(damageCanvas, transform.position + transform.forward * 1.3f, Quaternion.identity);
        canvas.GetComponentInChildren<Text>().text = damage.ToString();
        canvas.transform.LookAt(FindObjectOfType<Player2>().transform.position);

        if (hp <= 0)
        {
            FindObjectOfType<GameManager2>().EnemyCount++;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Player2>().HitDamage(1);
        FindObjectOfType<GameManager2>().EnemyCount++;
        Destroy(gameObject);
    }


}
