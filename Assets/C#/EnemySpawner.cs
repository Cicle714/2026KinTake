using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Player player;
    [SerializeField]
    List<Enemy> enemys;

    GameManager gameManager;

    [SerializeField]
    private float[] SpawnTimes;
    private float SpawnCount;

    [SerializeField]
    private float SpawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCount += Time.deltaTime;
        if(SpawnCount >= SpawnTimes[gameManager.GameLevel])
        {
            int Ram = Random.Range(0, 2);
            Enemy cloneEnemy = new Enemy();
            cloneEnemy = Instantiate(enemys[Ram], new Vector3(Random.Range(-SpawnPosition, SpawnPosition), 1, Random.Range(-SpawnPosition, SpawnPosition)), Quaternion.identity);
            cloneEnemy.MoveSpeed = Random.Range(1,3) + gameManager.GameLevel / (Ram + 1);
            SpawnCount = 0;
        }
    }
}
