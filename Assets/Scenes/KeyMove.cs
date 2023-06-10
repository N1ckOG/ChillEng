using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float speed = 20f;
    public float gravity = -25f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.2f;
    Vector3 velocity;

    bool isGrounded;

    
    void Update()
    {
//Гравитация
    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
//Уровень пола
    if (isGrounded && velocity.y < 0)
    {
        velocity.y = -2f;
    }
//Управление WASD
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 move = transform.right * x + transform.forward * z;
    controller.Move(move * speed * Time.deltaTime);

    velocity.y += gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);
//Прыжок
    if(Input.GetButtonDown("Jump") && isGrounded)
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
//Приседание
    if (Input.GetKey("c"))
    { 
        controller.height = 1f;
    } else
    {
        controller.height = 2f;
    }

//Ускорение
        if (Input.GetKey("left shift"))
    { 
        speed = 50f;
    } else
    {
        speed = 20f;
    }
    }
} 
