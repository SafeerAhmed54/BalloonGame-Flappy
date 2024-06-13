using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float startPosX;

    void Start()
    {
        startPosX = transform.localPosition.x;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveBackgroundx();
    }

    void MoveBackgroundx()
    {
        rb.velocity = Vector3.left * speed;

        if (transform.position.x <= -8.885f)
        {
            transform.localPosition = new Vector3(startPosX , transform.localPosition.y , transform.localPosition.z);
        }
    }
}
