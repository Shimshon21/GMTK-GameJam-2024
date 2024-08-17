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
        Boolean isNameTrue = givenItem.name == actualItem.name;
        Boolean isWeightTrue = givenItem.weight == actualItem.weight;
        Boolean isQualityTrue = givenItem.isGoodQuality == actualItem.isGoodQuality;
        Boolean isPriceTrue = givenItem.price == actualItem.price;

        if(isNameTrue && isWeightTrue && isQualityTrue)
        {
            return true;
        }
        else
        {
            return false;
        }
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
