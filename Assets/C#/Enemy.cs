using UnityEngine;

public class Enemy: MonoBehaviour
{
    [SerializeField]
    private int EnemyHP;
    public int enemyHP
    {
        get {  return EnemyHP; }
        set { EnemyHP = value; }
    }

    public float MoveSpeed;

    Player player;
    GameManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<Player>();
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyHP <= 0){
            manager.AddScore(10);
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, (MoveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            player.PlayerHp--;
        }
    }


}
