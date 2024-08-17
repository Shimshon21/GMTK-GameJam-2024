using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoteButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject note;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowNote()
    {
        print("Show note button pressed");
        note.SetActive(true);
    }

    private void OnMouseEnter()
    {
        print("Mouse over");
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    private void OnMouseExit()
    {
        print("Mouse out");
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ShowNote();
    }
}
