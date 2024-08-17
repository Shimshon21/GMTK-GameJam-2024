using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class TransactionButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Game game;
    [SerializeField] bool isAcceptButton;

    // Start is called before the first frame update
    void Start()
    {
        game = FindAnyObjectByType<Game>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ValidateDecision()
    {
        if (isAcceptButton)
        {
            game.AcceptPressed();
        }
        else
        {
            game.RefusePressed();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ValidateDecision();
    }
}
