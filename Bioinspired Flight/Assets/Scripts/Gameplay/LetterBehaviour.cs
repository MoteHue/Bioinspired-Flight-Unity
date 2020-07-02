using UnityEngine;

public class LetterBehaviour : MonoBehaviour {

    public CollectionState state = CollectionState.Uncollected;

    Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            state = CollectionState.Held;
            transform.SetParent(collision.gameObject.transform);
            transform.localPosition = new Vector3(0f, 2f, 0f);
            transform.localEulerAngles = Vector3.zero;
            GetComponent<BoxCollider>().enabled = false;
            anim.SetBool("isHeld", true);
        }
    }
}