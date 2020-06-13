using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtensionsMethods;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public Slider heightSlider;
    public Slider rotationSlider;
    public Transform hitbox;

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

        //Apply force
        GetComponent<ConstantForce>().relativeForce = new Vector3(xForce, yForce, zForce);

        //Tilt
        if (joystickHeld) {
            float xRotation = rotations.x + joystick.Vertical * tiltSpeed;
            float zRotation = rotations.z - joystick.Horizontal * tiltSpeed;
            rotations = new Vector3(xRotation, 0f, zRotation);
            checkTiltBounds();
        }
        else rotateBackToUpright();
        hitbox.rotation = Quaternion.Euler(rotations);

    }

    void checkTiltBounds() {
        if (rotations.x > maxTilt) {
            rotations.x = maxTilt;
        }
        else if (rotations.x < -maxTilt) {
            rotations.x = -maxTilt;
        }
        if (rotations.z > maxTilt) {
            rotations.z = maxTilt;
        }
        else if (rotations.z < -maxTilt) {
            rotations.z = -maxTilt;
        }
    }

    void rotateBackToUpright() {
        rotations = rotations.Round(1);
        if (rotations.x != 0) {
            if (rotations.x < 0) rotations.x += 0.2f;
            else rotations.x -= 0.2f;
        }
        if (rotations.z != 0) {
            if (rotations.z < 0) rotations.z += 0.2f;
            else rotations.z -= 0.2f;
        }
    }

    public void setJoystickHeld(bool b) {
        joystickHeld = b;
    }

}


