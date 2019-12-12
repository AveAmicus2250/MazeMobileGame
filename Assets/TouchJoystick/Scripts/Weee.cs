using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weee : MonoBehaviour
{
    public JoystickInput joystick;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 inputDir = joystick.GetAxis();
        print(inputDir);
        Vector2 newPos = Vector2.zero;

        newPos.x = inputDir.x * speed * Time.deltaTime;
        newPos.y = inputDir.y * speed * Time.deltaTime;

        transform.position += new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
