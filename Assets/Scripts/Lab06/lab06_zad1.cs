using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab06_zad1 : MonoBehaviour
{
    public float platformSpeed = 0.5f;
    private bool isRunning = false;
    private bool isRunningForward = true;
    private bool isRunningBackward = false;
    private float startPosition;
    private float endPosition;
    private Transform oldParent;

    void Start()
    {
        startPosition = transform.position.x;
        endPosition = transform.position.x + 5;
    }

    void FixedUpdate()
    {
        if (isRunningForward && transform.position.x >= endPosition)
        {
            isRunning = false;
        }
        else if (isRunningBackward && transform.position.x <= startPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.right * platformSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na platformê.");
            isRunning = true;
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;

            if (transform.position.x >= startPosition)
            {
                isRunningBackward = true;
                isRunningForward = false;
                platformSpeed = -platformSpeed;
            }
            else if (transform.position.x <= endPosition)
            {
                isRunningForward = true;
                isRunningBackward = false;
                platformSpeed = Mathf.Abs(platformSpeed);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z platformy.");
            isRunning = false;
            other.gameObject.transform.parent = oldParent;
        }
    }
}