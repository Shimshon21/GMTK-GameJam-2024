using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForSale : MonoBehaviour
{
    [SerializeField] private ItemProperties givenItem;

    [SerializeField] private ItemProperties actualItem;

    [SerializeField] public string note;

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

    public string failedText()
    {
        if (IsItemOk())
        {
            return "What are you doing?? this is a great price!";
        }

        return "Bloody hell, why did you bought this item?!";
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
