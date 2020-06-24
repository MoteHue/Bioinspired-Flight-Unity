using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelipadBehaviour : MonoBehaviour
{

    int collectedLoopCount;
    GameObject[] loops;

    // Start is called before the first frame update
    void Start() {
        loops = GameObject.FindGameObjectsWithTag("Loop");
        if (loops.Length == 0) {
            Debug.Log("Helipad is present without any loops.");
        }
        for (int i = 0; i < loops.Length; i++) {
            if (loops[i].GetComponent<LoopBehaviour>().id != 0) {
                loops[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && collectedLoopCount == loops.Length) {
            Debug.Log("Level complete");
        }
    }

    public void informLoopCollected() {
        collectedLoopCount += 1;
        foreach (GameObject loop in loops) {
            if (loop.GetComponent<LoopBehaviour>().id == collectedLoopCount) {
                loop.SetActive(true);
            }
        }
    }

}
