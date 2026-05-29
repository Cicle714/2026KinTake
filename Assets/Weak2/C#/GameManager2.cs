using UnityEngine;
using UnityEngine.SceneManagement;
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

    private float SceneMoveCount = 0;
    private float SceneMoveTime = 2;

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
            SceneMoveCount+= Time.deltaTime;
            gameClear.gameObject.SetActive(true);
            if(SceneMoveCount >= SceneMoveTime)
            {
                SceneManager.LoadScene("Weak2_Title");
            }
        }
    }
}
