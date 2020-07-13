using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FuelBehaviour : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other) {
        playerController.informFuelCollected();
        Destroy(gameObject);
    }
}
