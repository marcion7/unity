using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab04_zad4_Look : MonoBehaviour
{
    // ruch wok� osi Y b�dzie wykonywany na obiekcie gracza, wi�c
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;
    private float mouseYMove;
    private float xMin = -90;
    private float xMax = 90;
    void Start()
    {
        // zablokowanie kursora na �rodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy warto�ci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYMove += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        mouseYMove = Mathf.Clamp(mouseYMove, xMin, xMax);

        // wykonujemy rotacj� wok� osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // a dla osi X obracamy kamer� dla lokalnych koordynat�w
        // -mouseYMove aby unikn�� ofektu mouse inverse
        transform.localEulerAngles = new Vector3(-mouseYMove, 0, 0);

    }
}