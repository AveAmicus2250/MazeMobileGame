using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    [Header("MOVEMENT VARIABLES")]
    [Space(100)]
    [Header("Mini Header")]
    [Range(0f, 10f)]
    public float speed = 6.0f;
    //public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float maxForwardSpeed;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    public JoystickInput joystick;


    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(JoystickInput(joystick).x, 0, JoystickInput(joystick).y);

            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= speed;
            //if (Input.GetButton("Jump"))
            //{
                //moveDirection.y = jumpSpeed;
            //}
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            maxForwardSpeed = 15.0f;
        }
    }

    Vector2 JoystickInput(JoystickInput joystick)
    {
        Vector2 inputDir = joystick.GetAxis();
        Vector2 newPos = Vector2.zero;
        newPos.x = inputDir.x;
        newPos.y = inputDir.y;
        return newPos;
    }
}
