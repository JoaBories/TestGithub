using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnGroundTrigger : MonoBehaviour
{
    public bool IsGround;

    private Vector3 initialLocalPosition;

    private void Start()
    {
        initialLocalPosition = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = initialLocalPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            IsGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            IsGround = false;
        }
    }
}
