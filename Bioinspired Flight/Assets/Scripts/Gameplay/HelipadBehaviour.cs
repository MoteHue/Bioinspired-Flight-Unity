using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HelipadBehaviour : MonoBehaviour
{
    List<GameObject> uncollectedLoops;

    // Start is called before the first frame update
    void Start() {
        uncollectedLoops = GameObject.FindGameObjectsWithTag("Loop").ToList();
        if (uncollectedLoops.Count == 0) {
            Debug.Log("Helipad is present without any loops.");
        } else {
            for (int i = 0; i < uncollectedLoops.Count; i++) {
                if (uncollectedLoops[i].GetComponent<LoopBehaviour>().id != 0) {
                    uncollectedLoops[i].SetActive(false);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && uncollectedLoops.Count == 0) {
            Debug.Log("Level complete");
        }
    }

    public void informLoopCollected(GameObject collectedLoop) {
        uncollectedLoops.Remove(collectedLoop);
        foreach (GameObject loop in uncollectedLoops) {
            if (loop.GetComponent<LoopBehaviour>().id == collectedLoop.GetComponent<LoopBehaviour>().id + 1) {
                loop.SetActive(true);
            }
        }
    }

}
