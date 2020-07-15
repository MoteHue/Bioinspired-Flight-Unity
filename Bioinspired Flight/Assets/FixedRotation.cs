using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour
{

    public float rotationSpeedScale = 1f;

    void FixedUpdate()
    {
        transform.Rotate(0f, 3f, 0f);
    }

}
