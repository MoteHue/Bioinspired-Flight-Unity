using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerBehaviour : MonoBehaviour
{

    public float rotationSpeedScale = 1f;

    ConstantForce constForce;
    float rotationSpeed;

    void Start() {
        constForce = GetComponent<ConstantForce>();
    }

    void FixedUpdate() {
        transform.Rotate(0f, rotationSpeed, 0f);
    }

    public void setRotationSpeed(float speed) {
        rotationSpeed = speed * rotationSpeedScale;
    }
}
