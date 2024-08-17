using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ScaleScript : MonoBehaviour
{
    [SerializeField] TMP_Text scale;

    private void OnTriggerEnter2D(Collider2D collision)
    {


       if (collision.GetComponent<ObjectForSale>() != null)
       {
            scale.text = $"{collision.GetComponent<ObjectForSale>().actualItem.weight}Kg";
            Debug.Log(collision.name);
            //Change ObjectText as its Scale value
       } else
        {
            Debug.Log("The item is not ObjectForSale");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ObjectForSale>() != null)
        {
            scale.text = "0Kg";
        }
    }
}
