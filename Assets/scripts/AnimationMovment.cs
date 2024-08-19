using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMovment : MonoBehaviour
{
    Vector3 targetPosition;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = FindObjectOfType<EnterPoint>().transform.position;

        targetPosition = FindObjectOfType<SellingPoint>().transform.position;

        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position != targetPosition)
        {
            float delta = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
        }
    }

    public void MoveToBuyer()
    {
        targetPosition = FindObjectOfType<BuyPoint>().transform.position;
        Destroy(gameObject, 2f);
    }

    public void MoveToSeller()
    {
        targetPosition = FindObjectOfType<ExitPoint>().transform.position;
        Destroy(gameObject, 2f);
    }
}
