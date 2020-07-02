using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBehaviour : MonoBehaviour
{
    public HelipadBehaviour helipad;
    public int id;
    public CollectionState state = CollectionState.Uncollected;

    private void OnTriggerEnter(Collider collision) {
        if (state == CollectionState.Uncollected) {
            helipad.informLoopCollected(gameObject);
            state = CollectionState.Collected;
        }
    }

}
