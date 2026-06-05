using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class destination : ColorManager3
{
  
    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player3>())
        {
            for (int i = 0; i < other.gameObject.GetComponent<Player3>().itemList.Count; i++)
            {
                if (other.gameObject.GetComponent<Player3>().itemList[i].gameObject.GetComponent<Renderer>().material.color == rend.material.color)
                {
                    GameObject tmp = other.gameObject.GetComponent<Player3>().itemList[i].gameObject;
                    other.gameObject.GetComponent<Player3>().itemList.Remove(other.gameObject.GetComponent<Player3>().itemList[i]);
                    Destroy(tmp);
                    other.gameObject.GetComponent<Player3>().ItemOrder();
                    return;
                }
            }
        }
    }
}
