using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Joystick joystick;
    public Slider heightSlider;
    public Slider rotationSlider;

    public float moveSpeed = 0.1f;
    public float ascentSpeed = 0.1f;
    public float rotationSpeed = 0.1f;

    Vector3 velocity = new Vector3();

    // Update is called once per frame
    void Update()
    {
        velocity.x = joystick.Horizontal * moveSpeed;
        velocity.z = joystick.Vertical  * moveSpeed;
        velocity.y = heightSlider.value * ascentSpeed;

        transform.position += velocity;
        transform.Rotate(0f, rotationSlider.value * rotationSpeed, 0f, Space.Self);
    }

}
