using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MagnifyingGlassScript : MonoBehaviour
{
    private Vector3 OriginalPosition;
    float DragOffset = 0.5f;
    private GameObject LeftBoundary;
    private GameObject RightBoundary;
    private GameObject TopBoundary;
    private GameObject BottomBoundary;
    private Vector3 difference = Vector3.zero;
    private bool CanUse = false;
    [SerializeField] TMP_Text MagnifyingGlassText;

   

    private void Start()
    {
        OriginalPosition = transform.position ;
        GameObject[] borders = GameObject.FindGameObjectsWithTag("Borders");
        foreach (GameObject border in borders)
        {
            if (LeftBoundary == null || border.transform.position.x < LeftBoundary.transform.position.x)
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
        CanUse = true;
        difference = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector3)transform.position;
    }
    private void OnMouseDrag()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (MousePosition.x < LeftBoundary.transform.position.x + DragOffset || MousePosition.x > RightBoundary.transform.position.x - DragOffset
           || MousePosition.y > TopBoundary.transform.position.y - DragOffset || MousePosition.y < BottomBoundary.transform.position.y + DragOffset)
        {
            return;
        }
        else transform.position = (Vector3)MousePosition - difference;
    }
    private void OnMouseUp()
    {
        MagnifyingGlassText.gameObject.SetActive(false);
        CanUse = false;
        transform.position = OriginalPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ObjectForSale>() != null)
        {
            if (CanUse)
            {
                MagnifyingGlassText.gameObject.SetActive(true);
                if (collision.gameObject.GetComponent<ObjectForSale>() != null)
                MagnifyingGlassText.transform.position = transform.position + new Vector3(2.2f,1, 0);
            }
        }
        
    }
    private void OnTriggerExit2D()
    {
        MagnifyingGlassText.gameObject.SetActive(false);
    }
   
    
}
