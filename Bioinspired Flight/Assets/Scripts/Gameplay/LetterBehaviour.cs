using UnityEngine;

public class LetterBehaviour : MonoBehaviour {

    public CollectionState state = CollectionState.Uncollected;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            state = CollectionState.Held;
            transform.SetParent(collision.gameObject.transform);
        }
    }
}