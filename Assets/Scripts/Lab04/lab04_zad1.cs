using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lab04_zad1: MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int NumberOfObjects;
    // obiekt do generowania
    public GameObject block;
    public Material[] material;

    void Start()
    {
        Mesh planeMesh = this.GetComponent<MeshFilter>().mesh;
        Bounds bounds = planeMesh.bounds;
        int width = (int)Math.Round(this.transform.localScale.x * bounds.size.x);
        int height = (int)Math.Round(this.transform.localScale.z * bounds.size.z);
        int x_pos = (int)this.transform.position.x - width / 2;
        int z_pos = (int)this.transform.position.z - height / 2;
        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range(x_pos, width).OrderBy(x => Guid.NewGuid()).Take(NumberOfObjects));
        List<int> pozycje_z = new List<int>(Enumerable.Range(z_pos, height).OrderBy(x => Guid.NewGuid()).Take(NumberOfObjects));

        for (int i = 0; i < NumberOfObjects; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i]+0.5f, 5, pozycje_z[i] + 0.5f));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            this.block.GetComponent<Renderer>().material = material[UnityEngine.Random.Range(0, material.Length)];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}