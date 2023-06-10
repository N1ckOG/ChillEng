 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public Transform playerBody;

    private Vector3 startingRotation;

    public float mouseSens = 100f;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 10 * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 10 * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Запоминаем начальный поворот камеры
        //startingRotation = transform.rotation.eulerAngles;
        //transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}