using UnityEngine;

public class Enemy: MonoBehaviour
{
    [SerializeField]
    private int EnemyHP;
    public int enemyHP
    {
        get {  return EnemyHP; }
        set { EnemyHP = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyHP <= 0){
            Destroy(gameObject);
        }
    }
}
