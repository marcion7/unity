using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skrzynia : MonoBehaviour
{

    public float force = 10.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // sk³adowa y wektora prêdkoœci
        if (rb.velocity.y == 0)
        {
            // dzia³amy si³¹ na cia³o A :)
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}