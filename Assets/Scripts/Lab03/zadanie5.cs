using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class zadanie5 : MonoBehaviour
{
    public GameObject myPrefab;
    List<Vector3> positions = new List<Vector3>(10);

    void Start()
    {
        while (positions.Count < 10)
        {
            //var position = new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f));
            var position = new Vector3(Random.Range(-10.0f, 10.0f), 0.5f, Random.Range(-10.0f, 10.0f));
            if (!positions.Contains(position))
            {
                Instantiate(myPrefab, position, Quaternion.identity);
                positions.Add(position);
            }
        }
    }
}