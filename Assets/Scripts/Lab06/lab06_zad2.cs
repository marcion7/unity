using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab06_zad2 : MonoBehaviour
{
    public float doorSpeed = 0.1f;
    private bool isRunning = false;
    private bool isRunningForward = true;
    private bool isRunningBackward = false;
    private float startPosition;
    private float endPosition;
    Vector3 move;

    void Start()
    {
        startPosition = transform.position.x;
        endPosition = transform.position.x + 1;
    }

    void Update()
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
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player podszed³ do drzwi.");
            if (transform.position.x <= endPosition)
            {
                isRunningForward = true;
                isRunningBackward = false;
                move = -transform.right * doorSpeed * Time.deltaTime;
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player odszed³ od drzwi.");
            if (transform.position.x >= startPosition)
            {
                isRunningForward = false;
                isRunningBackward = true;
                move = transform.right * doorSpeed * Time.deltaTime;
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
        }
    }
}