using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField]
    Text GoalText;

    [SerializeField]
    private float MoveTime;
    private float MoveCount;    

    private bool isGoal = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player1>())
        {
            GoalText.gameObject.SetActive(true);
            isGoal = true;
            FindObjectOfType<Score>().ResultScore((int)Timer.CountDown);
            Timer.CountStop = true;
        }
    }

    private void Update()
    {
        if (isGoal)
        {
            MoveCount += Time.deltaTime;
            if (MoveCount >= MoveTime)
            {
                for (int i = 0; i <= 10; i++)
                {
                    if (SceneManager.GetActiveScene().name == "Weak1_" + (i).ToString())
                    {
                        if (Application.CanStreamedLevelBeLoaded("Weak1_" + (i + 1).ToString()))
                            SceneManager.LoadScene("Weak1_" + (i+1).ToString());
                        else
                            SceneManager.LoadScene("Weak1_Title");
                    } 
                }
            }
        }
    }

}
