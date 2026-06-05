using System.Collections.Generic;
using UnityEngine;

public class ColorManager3 : MonoBehaviour
{
    [SerializeField]
    public List<Material> material;


   public enum ItemColor
    {
        Red,
        Green,
        Blue,
    }
    [SerializeField]
    static public ItemColor MyColor;
    public ItemColor myColor
    {
        get { return MyColor; }
    }
}
