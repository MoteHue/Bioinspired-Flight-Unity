using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Joystick joystick;
    public Slider heightSlider;
    public Slider rotationSlider;

    float horizontalDrag = 0f;
    float verticalDrag = 0f;

    public float gravity = 0.1f;
    public float horizontalAcceleration = 2f;
    public float maxMoveSpeed = 10f;
    public float rotationSpeed = 0.5f;

    public float verticalAcceleration = 5f;
    public float maxAscentSpeed = 10f;

    bool sliderHeld;
    bool joystickHeld;

    public Vector3 velocityDebugView;

    private void Update() {
        // Receive force values 
        float xForce = joystick.Horizontal * horizontalAcceleration;
        float zForce = joystick.Vertical * horizontalAcceleration;
        float yForce = heightSlider.value * verticalAcceleration;

        rb.AddRelativeForce(new Vector3(xForce, yForce, zForce));

        // Force are graduall cancelled when the slider/joystick is released.
        CalculateDrags();

        // Clamp the velocities, so the drone can't accelerate forever.
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxMoveSpeed, maxMoveSpeed), Mathf.Clamp(rb.velocity.y, -maxAscentSpeed, maxAscentSpeed),
            Mathf.Clamp(rb.velocity.z, -maxMoveSpeed, maxMoveSpeed));

        transform.Rotate(new Vector3(0f, rotationSlider.value * rotationSpeed, 0f));

        velocityDebugView = rb.velocity;

    }

    void FixedUpdate() {
        Vector3 vel = rb.velocity;
        vel.x *= 1f - horizontalDrag; // Reduce x component...
        vel.y *= 1f - verticalDrag; // and y component...
        vel.z *= 1f - horizontalDrag; // and z component each cycle.
        rb.velocity = vel;
    }

    void CalculateDrags() {
        // Vertical drag.
        if (sliderHeld == false) {
            verticalDrag = 0.05f;
            if (rb.velocity.y == 0f) {
                HoverMode();
            }
        }
        else {
            verticalDrag = 0f;
        }
        // Horizontal drag.
        if (joystickHeld == false) {
            horizontalDrag = 0.05f;
        }
        else {
            horizontalDrag = 0f;
        }
    }

    public void NotifySliderIsHeld() {
        sliderHeld = true;
    }

    public void NotifySliderReleased() {
        sliderHeld = false;
    }

    public void NotifyJoystickIsHeld() {
        joystickHeld = true;
    }

    public void NotifyJoystickReleased() {
        joystickHeld = false;
    }

    void HoverMode() {

    }

}
