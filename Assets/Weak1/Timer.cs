using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text CountDownText;
    [SerializeField]
    private float TimeMax;
    static public float CountDown;
    static public bool CountStop;
    void Start()
    {
        CountStop = false;
        CountDown = TimeMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDown >= 0)
        {
            if(!CountStop)
            CountDown -= Time.deltaTime;
        }
        else
        {
            FindObjectOfType<Player1>().TimeUp();
            CountDown = 0;
        }

            CountDownText.text = CountDown.ToString("F2");
    }
}
