using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie3 : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public float speed;
    public float distance;
    private string direction = "forward";
    private float selecteddist;

    void Update()
    {
        if (transform.position.z < distance && direction == "forward")
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z >= distance && transform.position.x <= distance)
            {
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                direction = "right";
            }
        }
        else if (transform.position.x < distance && direction == "right")
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z >= distance && transform.position.x >= distance)
            {
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                selecteddist = distance;
                distance = 0;
                direction = "backwards";
            }
        }
        else if (transform.position.z > distance && transform.position.x > distance && direction == "backwards")
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z <= distance && transform.position.x >= distance)
            {
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                direction = "left";
            }
        }
        else if (transform.position.z < distance && transform.position.x > distance && direction == "left")
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z <= distance && transform.position.x <= distance)
            {
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                distance = selecteddist;
                distance = selecteddist;
                direction = "forward";
            }
        }

    }
}