using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{

    public float rotationSpeedScale = 1f;

    float rotationSpeed = 1f;
    void FixedUpdate()
    {
        transform.Rotate(0f, rotationSpeed, 0f);
    }

}
