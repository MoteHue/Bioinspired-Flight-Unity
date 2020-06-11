using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Slider heightSlider;
    public Slider rotationSlider;

    public float horizontalAcceleration = 15f;
    public float rotationSpeed = 0.5f;

    private void Update() {
        // Receive force values 
        float xForce = joystick.Horizontal * horizontalAcceleration;
        float zForce = joystick.Vertical * horizontalAcceleration;
        float yForce = heightSlider.value * 9.81f;

        // Rotate
        transform.Rotate(new Vector3(0f, rotationSlider.value * rotationSpeed, 0f));

        //Apply force
        GetComponent<ConstantForce>().relativeForce = new Vector3(xForce, yForce, zForce);

    }

}
