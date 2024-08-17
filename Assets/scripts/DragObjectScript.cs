using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class DragObjectScript : MonoBehaviour
{
    float DragOffset = 0.5f;
    private GameObject LeftBoundary;
    private GameObject RightBoundary;
    private GameObject TopBoundary;
    private GameObject BottomBoundary;
    private Vector3 difference = Vector3.zero;
    [SerializeField] TextMeshProUGUI ObjectText;
    
    private void Start()
    {        
        GameObject[] borders = GameObject.FindGameObjectsWithTag("Borders");
        foreach(GameObject border in borders)
        {
            if(LeftBoundary == null || border.transform.position.x < LeftBoundary.transform.position.x)
            {
                LeftBoundary = border;
            }
            if (RightBoundary == null || border.transform.position.x > RightBoundary.transform.position.x)
            {
                RightBoundary = border;
            }
            if (TopBoundary == null || border.transform.position.y > TopBoundary.transform.position.y)
            {
                TopBoundary = border;
            }
            if (BottomBoundary == null || border.transform.position.y < BottomBoundary.transform.position.y)
            {
                BottomBoundary = border;
            }
        }
    }

    private void OnMouseDown()
    {
        ObjectText.gameObject.SetActive(true);
        difference = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector3)transform.position;
    }

    private void OnMouseUp()
    {
        ObjectText.gameObject.SetActive(false);
    }

    private void OnMouseDrag()
    {
        //Change ObjectText as Object Name
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (MousePosition.x < LeftBoundary.transform.position.x + DragOffset || MousePosition.x > RightBoundary.transform.position.x - DragOffset
           || MousePosition.y > TopBoundary.transform.position.y - DragOffset || MousePosition.y < BottomBoundary.transform.position.y + DragOffset)
        {
            return;
        }
        else
        {
            transform.position = (Vector3)MousePosition - difference;
        }

        ObjectText.transform.position = transform.position + new Vector3(0, 1, 0);
        Debug.Log(ObjectText.transform.position);
    }
}
