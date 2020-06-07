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

    public float gravity = 0.1f;
    public float horizontalAcceleration = 2f;
    public float maxMoveSpeed = 10f;
    public float rotationSpeed = 0.5f;

    public float verticalAcceleration = 5f;
    public float maxAscentSpeed = 10f;

    private void Start() {

    }

    private void Update() {
        float x = joystick.Horizontal * horizontalAcceleration;
        float z = joystick.Vertical * horizontalAcceleration;
        float y = heightSlider.value * verticalAcceleration;
        float rot = rotationSlider.value;
        Quaternion rotation = Quaternion.Euler(0f, rot, 0f);

        rb.AddRelativeForce(new Vector3(x, y, z));

        rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -maxAscentSpeed, maxAscentSpeed),rb.velocity.z);
        rb.MoveRotation(rotation);
    }

    private void OnCollisionEnter(Collision collision) {
        
    }

    private void OnCollisionExit(Collision collision) {
        
    }

}
