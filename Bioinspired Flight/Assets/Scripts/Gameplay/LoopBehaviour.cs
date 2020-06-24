using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBehaviour : MonoBehaviour
{
    public HelipadBehaviour helipad;
    public int id;
    bool collected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision) {
        if (!collected) {
            helipad.informLoopCollected();
            collected = true;
        }
    }

    public void testing() {
        Debug.Log("Testing");
    }

}
