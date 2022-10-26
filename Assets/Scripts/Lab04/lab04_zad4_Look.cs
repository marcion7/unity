using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab04_zad4_Look : MonoBehaviour
{
    // ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza, wiêc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;
    private float mouseYMove;
    private float xMin = -90;
    private float xMax = 90;
    void Start()
    {
        // zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartoœci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYMove += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        mouseYMove = Mathf.Clamp(mouseYMove, xMin, xMax);

        // wykonujemy rotacjê wokó³ osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // a dla osi X obracamy kamerê dla lokalnych koordynatów
        // -mouseYMove aby unikn¹æ ofektu mouse inverse
        transform.localEulerAngles = new Vector3(-mouseYMove, 0, 0);

    }
}