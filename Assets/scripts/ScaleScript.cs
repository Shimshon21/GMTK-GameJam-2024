using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.name == "Object")
       {
            Debug.Log(collision.name);
            //Change ObjectText as its Scale value
       }
    }
}
