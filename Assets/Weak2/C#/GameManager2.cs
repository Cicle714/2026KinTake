using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    [SerializeField]
    public int EnemyNum = 50;
    public int EnemyNumNow = 0;
    public int EnemyCount = 0;
    [SerializeField]
    private Text EnemyNumText;
    [SerializeField]
    private Text gameClear;
    void Start()
    {
        EnemyNumNow = EnemyNum;
    }
    // Update is called once per frame
    void Update()
    {
        EnemyNumText.text = "Žc‚èEnemy " + (EnemyNum - EnemyCount).ToString();
        if (EnemyNum <= EnemyCount)
        {
            gameClear.gameObject.SetActive(true);
        }
    }
}
