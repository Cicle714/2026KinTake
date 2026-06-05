using UnityEngine;

public class ItemSpawner3 : MonoBehaviour
{
    [SerializeField]
    Item3 item;

    private float SpawnTime = 2.0f; //スポーン時間
    private float SpawnCounter = 0.0f; //スポーンカウンター

    // Update is called once per frame
    void Update()
    {
        SpawnCounter += Time.deltaTime;
        if (SpawnCounter >= SpawnTime)
        {
            SpawnCounter = 0.0f;
            Item3 newItem = Instantiate(item, new Vector3(Random.Range(-9,9),0.75f,Random.Range(-9,9)), Quaternion.identity);
            newItem.colorNum = Random.Range(0, 3);
        }
    }
}
