using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtensionsMethods;
using System.Net.Sockets;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    [Header("GameObjects")]
    public Joystick joystick;
    public Slider heightSlider;
    public Slider rotationSlider;
    public Transform hitbox;
    public Camera playerCamera;

    [Header("Player Settings")]
    public float horizontalAcceleration = 25f;
    public float rotationSpeed = 1f;
    public float tiltSpeed = 90f;
    public float tiltReturnSpeed = 30f;
    public float maxTilt = 15f;
    public float cameraSmoothSpeed = 10f;

    bool joystickHeld;
    Vector3 hitboxRotations;
    Vector3 forces;

    private void Update() { // Called once per frame
        // Receive joystick and slider values 
        forces.x = joystick.Horizontal * horizontalAcceleration;
        forces.y = heightSlider.value * 9.81f;
        forces.z = joystick.Vertical * horizontalAcceleration;

        // Rotate player
        transform.Rotate(new Vector3(0f, rotationSlider.value * rotationSpeed, 0f));
    }

    private void FixedUpdate() { // Called a set number of times per second (separate from framerate)
        // Apply force
        GetComponent<ConstantForce>().relativeForce = forces;

        // Tilt
        tilt();

        // Offset the camera with the tilt
        playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, new Vector3(-hitboxRotations.z / 20f, 3f, -8f + hitboxRotations.x / 20f), cameraSmoothSpeed * Time.deltaTime);
    }

    #region Tilting
    void tilt() {
        if (joystickHeld) {
            float xRotation = hitboxRotations.x + joystick.Vertical * tiltSpeed * Time.deltaTime;
            float zRotation = hitboxRotations.z - joystick.Horizontal * tiltSpeed * Time.deltaTime;
            hitboxRotations = new Vector3(xRotation, 0f, zRotation);
            checkTiltBounds();
        } else {
            rotateBackToUpright();
        }
        hitbox.localRotation = Quaternion.Euler(hitboxRotations);
    }

    void checkTiltBounds() {
        // x bounds
        if (hitboxRotations.x > maxTilt) {
            hitboxRotations.x = maxTilt;
        } else if (hitboxRotations.x < -maxTilt) {
            hitboxRotations.x = -maxTilt;
        }

        // z bounds
        if (hitboxRotations.z > maxTilt) {
            hitboxRotations.z = maxTilt;
        } else if (hitboxRotations.z < -maxTilt) {
            hitboxRotations.z = -maxTilt;
        }
    }

    void rotateBackToUpright() {
        hitboxRotations = hitboxRotations.Round(1);
        // x axis
        if (hitboxRotations.x != 0f) {
            if (hitboxRotations.x < 0f) hitboxRotations.x += tiltReturnSpeed * Time.deltaTime;
            else hitboxRotations.x -= tiltReturnSpeed * Time.deltaTime;
        }

        // z axis
        if (hitboxRotations.z != 0f) {
            if (hitboxRotations.z < 0f) hitboxRotations.z += tiltReturnSpeed * Time.deltaTime;
            else hitboxRotations.z -= tiltReturnSpeed * Time.deltaTime;
        }

        // Set to zero if close (possibly floating point precision error?)
        if (hitboxRotations.x < 1f && hitboxRotations.x > -1f) hitboxRotations.x = 0f;
        if (hitboxRotations.z < 1f && hitboxRotations.z > -1f) hitboxRotations.z = 0f;
    }
    #endregion

    public void setJoystickHeld(bool b) {
        joystickHeld = b;
    }

}


