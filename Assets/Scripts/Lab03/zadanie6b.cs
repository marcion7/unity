using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie6b : MonoBehaviour
{
    // animate the game object from 0 to 3 and back
    public float minimum = 0.0f;
    public float maximum = 3.0f;

    // starting value for the Lerp
    static float t = 0.0f;

    void Update()
    {
        // animate the position of the game object...
        transform.position = new Vector3(4, Mathf.Lerp(minimum, maximum, t), 0);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 2.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 2.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}