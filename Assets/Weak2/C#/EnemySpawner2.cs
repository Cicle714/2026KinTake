using System.Net;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnInterval = 2f;

    private float spawnCount = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager2>().EnemyNumNow > 0)
        {

            spawnCount += Time.deltaTime;
        }
        if (spawnCount >= spawnInterval)
        {
            int num = Random.Range(-10, 10);
            int num2 = Random.Range(-10, 10);
            if (num >= -2 && num <= 2 || num2 >= -2 && num2 <= 2)
                return;
            Instantiate(enemyPrefab, new Vector3(num,0.5f,num2), Quaternion.identity);
            spawnCount = 0f;
            FindObjectOfType<GameManager2>().EnemyNumNow--;
        }
    }
}
