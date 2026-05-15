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
        }
    }

    private void Update()
    {
        if (isGoal)
        {
            MoveCount += Time.deltaTime;
            if(MoveCount >= MoveTime)
            {
                SceneManager.LoadScene("Weak1_Title");
            }
        }
    }

}
