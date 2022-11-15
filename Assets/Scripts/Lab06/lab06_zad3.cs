using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab06_zad3 : MonoBehaviour
{
    public float platformSpeed = 0.3f;
    private bool isRunning = false;
    private Vector3 startPosition;
    private Transform oldParent;
    public List<Vector3> positions = new();
    private int i = 1;
    private int j = 0;
    private float counter = 0;

    void Start()
    {
        startPosition = transform.position;
        positions.Insert(0, startPosition);
    }

    void Update()
    {

           // Od pocz¹tku do ostatniego punktu
           if (isRunning && i < positions.Count)
           {
                counter += platformSpeed * Time.deltaTime;
                transform.position = Vector3.Lerp(positions[i - 1], positions[i], counter);
                if (Vector3.Distance(transform.position, positions[i]) == 0) {            
                    i += 1;
                    counter = 0;
                    if (i == positions.Count)
                    {
                        j = i - 1;
                    }
                }
           }

            // Od ostaniego punktu na pocz¹tek
            if (isRunning && j > 0)
               {
                    counter += platformSpeed * Time.deltaTime;
                    transform.position = Vector3.Lerp(positions[j], positions[j - 1], counter);
                    if (Vector3.Distance(transform.position, positions[j - 1]) == 0)
                    {
                        j -= 1;
                        counter = 0;
                        if (j < 0)
                        {
                            i = 1;
                        }
                    }
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