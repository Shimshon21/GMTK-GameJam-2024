using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationMovment : MonoBehaviour
{

    [SerializeField] Transform enterPoint;
    [SerializeField] Transform tablePoint;
    [SerializeField] Transform RejectedPoint;
    [SerializeField] Transform AcceptedPoint;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = enterPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
