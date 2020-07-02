using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HelipadBehaviour : MonoBehaviour
{

    int collectedLoopCount;
    List<GameObject> loops;

    // Start is called before the first frame update
    void Start() {
        loops = GameObject.FindGameObjectsWithTag("Loop").ToList<GameObject>();
        if (loops.Count == 0) {
            Debug.Log("Helipad is present without any loops.");
        } else {
            for (int i = 0; i < loops.Count; i++) {
                if (loops[i].GetComponent<LoopBehaviour>().id != 0) {
                    loops[i].SetActive(false);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && collectedLoopCount == loops.Count) {
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
