using UnityEngine;

public class DamageEfe : MonoBehaviour
{
    Vector3 textSize;
    Vector3 textPos;

    private float step = 0.25f;

    private float count1 = 0;
    private float count2 = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textSize = transform.localScale;
        textPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        count2 += Time.deltaTime;
        if (count1 <= step)
        {
            count1 += Time.deltaTime;
        }
        transform.localScale = Vector3.Lerp(Vector3.zero, textSize, count1 / step);
        if(count1 <= step / 2)
        transform.position = Vector3.Lerp(textPos, textPos + Vector3.up, count1 / step/2);
        else
        {
            transform.position = Vector3.Lerp(textPos + Vector3.up, textPos,  count1 / step);
        }

        if(count2 >= step * 4)
        {
            Destroy(gameObject);
        }

    }
}
