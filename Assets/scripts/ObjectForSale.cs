using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForSale : MonoBehaviour
{
    [SerializeField] private ItemProperties givenItem;

    [SerializeField] public ItemProperties actualItem;

    [TextArea] public string note;

    public bool IsItemOk()
    {
        if(givenItem.name == actualItem.name) {
            return false;
        }

        if (givenItem.price == actualItem.price)
        {
            return false;
        }

        if (givenItem.weight == actualItem.weight)
        {
            return false;
        }

        return true;
    }

}

[Serializable]
public struct ItemProperties
{
    public string name;

    public int price;

    public string weight;

    public bool isGoodQuality;
}
