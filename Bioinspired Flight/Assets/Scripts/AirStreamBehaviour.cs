using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStreamBehaviour : MonoBehaviour
{
    public float force = 20f;

    private void OnTriggerStay(Collider other) {
        other.attachedRigidbody.AddRelativeForce(transform.up * force);
    }
}
