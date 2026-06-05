using System.Collections.Generic;
using UnityEngine;

public class Item3 : ColorManager3
{
 
    public int colorNum; //êFÇÃî‘çÜ
    public bool haveItem = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().material = material[colorNum];
        switch (colorNum)
        {
            case 0:
                MyColor = ItemColor.Red;
                break;
            case 1:
                MyColor = ItemColor.Green;
                break;
            case 2:
                MyColor = ItemColor.Blue;
                break;
        }
    }

}
