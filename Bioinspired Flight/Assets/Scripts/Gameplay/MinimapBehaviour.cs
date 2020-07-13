using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapBehaviour : MonoBehaviour
{
    public Transform player;

    private void LateUpdate() {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        Vector3 newRotation = new Vector3(90f, player.rotation.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Euler(newRotation);
    }
}
