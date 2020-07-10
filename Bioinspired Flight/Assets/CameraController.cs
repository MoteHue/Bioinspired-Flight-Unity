using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;
    public int activeMenu = 0;


    public void updateView(int viewNumber)
    {
        UnityEngine.Debug.Log("Changing the activeMenu to:");
        activeMenu = viewNumber;
        UnityEngine.Debug.Log(activeMenu);
    }

    void Update()
    {
        currentView = views[activeMenu];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.Debug.Log("Should probably move to scene 3");
            activeMenu = 2;
            currentView = views[2];
        }
    }

    void LateUpdate()
    {
        // Lerp for position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        // Lerp for rotation
        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.rotation.eulerAngles.y, Time.deltaTime* transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.rotation.eulerAngles.z, Time.deltaTime* transitionSpeed));

        transform.eulerAngles = currentAngle;

    }
}
