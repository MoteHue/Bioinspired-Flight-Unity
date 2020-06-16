using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtensionsMethods;
using System.Net.Sockets;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Slider heightSlider;
    public Slider rotationSlider;
    public Transform hitbox;
    public Camera playerCamera;

    public float horizontalAcceleration = 15f;
    public float rotationSpeed = 0.5f;
    public float tiltSpeed = 0.1f;
    public float maxTilt = 20f;

    private bool joystickHeld;
    private Vector3 rotations;

    private void Update() {
        // Receive force values 
        float xForce = joystick.Horizontal * horizontalAcceleration;
        float zForce = joystick.Vertical * horizontalAcceleration;
        float yForce = heightSlider.value * 9.81f;

        // Rotate
        transform.Rotate(new Vector3(0f, rotationSlider.value * rotationSpeed, 0f));

        // Apply force
        GetComponent<ConstantForce>().relativeForce = new Vector3(xForce, yForce, zForce);

        // Tilt
        tilt();

    }

    void tilt() {
        if (joystickHeld) {
            float xRotation = rotations.x + joystick.Vertical * tiltSpeed;
            float zRotation = rotations.z - joystick.Horizontal * tiltSpeed;
            rotations = new Vector3(xRotation, 0f, zRotation);
            checkTiltBounds();
        } else {
            rotateBackToUpright();
        }
        hitbox.localRotation = Quaternion.Euler(rotations);
        // Offset the camera with the tilt
        playerCamera.transform.localPosition = new Vector3(-rotations.z / 20f, 3f, -8f + rotations.x / 20f);
    }

    void checkTiltBounds() {
        // x bounds
        if (rotations.x > maxTilt) {
            rotations.x = maxTilt;
        } else if (rotations.x < -maxTilt) {
            rotations.x = -maxTilt;
        }

        // z bounds
        if (rotations.z > maxTilt) {
            rotations.z = maxTilt;
        } else if (rotations.z < -maxTilt) {
            rotations.z = -maxTilt;
        }
    }

    void rotateBackToUpright() {
        rotations = rotations.Round(1);
        // x axis
        if (rotations.x != 0) {
            if (rotations.x < 0) rotations.x += 0.2f;
            else rotations.x -= 0.2f;
        }

        // z axis
        if (rotations.z != 0) {
            if (rotations.z < 0) rotations.z += 0.2f;
            else rotations.z -= 0.2f;
        }
    }

    public void setJoystickHeld(bool b) {
        joystickHeld = b;
    }

}


