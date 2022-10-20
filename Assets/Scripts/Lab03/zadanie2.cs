using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie2 : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public float speed;
    private bool stop = false;

    void Update()
    {
        if (transform.position.x < 10 && stop == false)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if(transform.position.x >= 10)
            {
                stop = true;
            }
        }
        else if (transform.position.x > 0 && stop == true)
        {
            transform.Translate(-(speed * Time.deltaTime), 0, 0);
            if (transform.position.x <= 0)
            {
                stop = false;
            }
        }
    }
}