using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    Text HpText;
    [SerializeField]
    Text ScoreText;
    [SerializeField]
    GameObject GameOver;
    Player player;

    [SerializeField]
    private float PlayTime;

    public int GameLevel;
    public int Score;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayTime = Time.time;

        if(GameLevel < 10)
        GameLevel = (int)PlayTime / 10;

        HpText.text = "HP:" + player.PlayerHp;

        if(player.PlayerHp <= 0)
        {
            GameOver.SetActive(true);
        }

        

    }
    public void AddScore(int num)
    {
        Score += num * ((GameLevel + 1) / 2);

        ScoreText.text = "Score:" + Score;
    }

    public void ReTry()
    {
        if (player.PlayerHp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
