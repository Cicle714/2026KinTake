using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float DeathTime;
    private float DeathCount;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed ;

        DeathCount += Time.deltaTime;
        if(DeathCount >= DeathTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().enemyHP--;
            Destroy(gameObject);
        }
    }

}
