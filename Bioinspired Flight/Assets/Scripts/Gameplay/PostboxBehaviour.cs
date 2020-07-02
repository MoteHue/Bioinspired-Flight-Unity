using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CollectionState { Uncollected, Held, Collected }

public class PostboxBehaviour : MonoBehaviour
{

    List<GameObject> uncollectedLetters;

    void Start() {
        uncollectedLetters = GameObject.FindGameObjectsWithTag("Letter").ToList();
        if (uncollectedLetters.Count == 0) {
            Debug.Log("Postbox is present without any letters.");
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (uncollectedLetters.Count == 0) {
                Debug.Log("Level complete");
            } else { 
                foreach (GameObject letter in uncollectedLetters.ToList()) {
                    if (letter.GetComponent<LetterBehaviour>().state == CollectionState.Held) {
                        letter.GetComponent<LetterBehaviour>().state = CollectionState.Collected;
                        uncollectedLetters.Remove(letter);
                        letter.SetActive(false);
                    }
                }
                if (uncollectedLetters.Count == 0) {
                    Debug.Log("Level complete");
                }
            }
        }
    }

}
