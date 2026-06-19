using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;
    private int myScore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResultScore(int time)
    {
        myScore = time * 200;
        ScoreText.text = "score:"+myScore.ToString();
        ScoreText.gameObject.SetActive(true);
    }
}
