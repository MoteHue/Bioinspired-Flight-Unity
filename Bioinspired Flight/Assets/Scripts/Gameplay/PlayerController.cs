using UnityEngine;
using UnityEngine.UI;
using ExtensionsMethods;
using UnityEngine.Rendering;
using Boo.Lang;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [Header("GameObjects")]
    public Joystick joystick;
    public Slider heightSlider;
    public Slider rotationSlider;
    public Transform hitbox;
    public Camera playerCamera;
    public PropellerBehaviour[] props;
    public GameObject fuelGague;
    public GameObject minimap;

    [Header("Player Settings")]
    public float horizontalAcceleration = 25f;
    public float verticalAcceleration = 2f;
    public float fallSpeed = 3f;
    public float rotationSpeed = 1f;
    public float tiltSpeed = 90f;
    public float tiltReturnSpeed = 30f;
    public float maxTilt = 15f;
    public float cameraSmoothSpeed = 10f;
    public float maxFuelLevel = 100f;
    public float fuelLossSpeed = 5f;

    [Header("Customisations")]
    public bool airSensorEnabled; // Shows air streams.
    public GameObject airSensor;
    public bool electricalSensorEnabled; // Shows waypoints on minimap.
    public GameObject electricalSensor;
    public bool softRoboticsGripperEnabled; // Allows picking up multiple collectibles.
    public GameObject softRoboticsGripper;
    public bool magnetometerEnabled; // Points towards next objective.
    public GameObject magnetometer;
    public bool camoflageSkinEnabled; // Harder to be spotted be searchlights (longer lockon time maybe?).
    public bool gpsEnabled; // Shows minimap.

    Rigidbody rb;
    bool joystickHeld;
    Vector3 hitboxRotations;
    Vector3 forces;
    float fuelLevel = 100f;
    GameObject[] fuels;
    SaveData loadoutData;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        loadoutData = new SaveData("Loadout.save");
        loadoutData.Load();
        airSensor.SetActive(loadoutData.data["Feathers"]);
        electricalSensor.SetActive(loadoutData.data["Hammerhead"]);
        softRoboticsGripper.SetActive(loadoutData.data["Octopus"]);
        magnetometer.SetActive(loadoutData.data["Turtle"]);
        minimap.SetActive(gpsEnabled);
        fuels = GameObject.FindGameObjectsWithTag("Fuel");
        if (fuels.Count() == 0) { fuelGague.gameObject.SetActive(false); }
    }

    private void Update() { // Called once per frame
        // Receive joystick and slider values 
        forces.x = joystick.Horizontal * horizontalAcceleration;
        forces.y = heightSlider.value * 9.81f * rb.mass;
        forces.z = joystick.Vertical * horizontalAcceleration;

        if (forces.y > 9.81f * rb.mass) {
            forces.y *= verticalAcceleration;
        } else if (forces.y < 0f) {
            forces.y *= fallSpeed;
        }

        // Rotate player
        transform.Rotate(new Vector3(0f, rotationSlider.value * rotationSpeed, 0f));

        if ((joystickHeld || heightSlider.value > -1) && fuelGague.activeSelf) {
            fuelLevel -= fuelLossSpeed * Time.deltaTime;
        }
    }

    private void FixedUpdate() { // Called a set number of times per second (separate from framerate)
        #region Propeller rotations
        float[] rotSpeeds = new float[4];

        // Height slider
        for (int i = 0; i < props.Length; i++) {
            rotSpeeds[i] += heightSlider.value + 1;
        }

        // Rotation slider
        if (rotationSlider.value > 0) { 
            rotSpeeds[0] += 2f * rotationSlider.value;
            rotSpeeds[3] += 2f * rotationSlider.value;
        } else if (rotationSlider.value < 0) {
            rotSpeeds[1] += 2f * -rotationSlider.value;
            rotSpeeds[2] += 2f * -rotationSlider.value;
        }

        // Joystick
        if (joystick.Horizontal > 0) {
            rotSpeeds[0] += 2f * joystick.Horizontal;
            rotSpeeds[2] += 2f * joystick.Horizontal;
        } else if (joystick.Horizontal < 0) {
            rotSpeeds[1] += 2f * -joystick.Horizontal;
            rotSpeeds[3] += 2f * -joystick.Horizontal;
        }
        if (joystick.Vertical > 0) {
            rotSpeeds[2] += 2f * joystick.Vertical;
            rotSpeeds[3] += 2f * joystick.Vertical;
        } else if (joystick.Vertical < 0) {
            rotSpeeds[0] += 2f * -joystick.Vertical;
            rotSpeeds[1] += 2f * -joystick.Vertical;
        }

        // Apply rotations
        for (int i = 0; i < props.Length; i++) {
            props[i].setRotationSpeed(rotSpeeds[i]);
        }
        #endregion

        // Apply force
        GetComponent<ConstantForce>().relativeForce = forces;

        // Tilt
        tilt();

        // Offset the camera with the tilt
        playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, new Vector3(-hitboxRotations.z / 20f, 3f, -8f + hitboxRotations.x / 20f), cameraSmoothSpeed * Time.deltaTime);
    }
    private void LateUpdate() {
        fuelGague.GetComponent<Slider>().value = fuelLevel;
        if (fuelLevel <= 0) {
            Debug.Log("Game Over, out of fuel!");
        }
    }

    #region Tilting
    void tilt() {
        if (joystickHeld) {
            float xRotation = hitboxRotations.x + joystick.Vertical * tiltSpeed * Time.deltaTime;
            float zRotation = hitboxRotations.z - joystick.Horizontal * tiltSpeed * Time.deltaTime;
            hitboxRotations = new Vector3(xRotation, 0f, zRotation);
            checkTiltBounds();
        } else {
            rotateBackToUpright();
        }
        hitbox.localRotation = Quaternion.Euler(hitboxRotations);
    }

    void checkTiltBounds() {
        // x bounds
        if (hitboxRotations.x > maxTilt) {
            hitboxRotations.x = maxTilt;
        } else if (hitboxRotations.x < -maxTilt) {
            hitboxRotations.x = -maxTilt;
        }

        // z bounds
        if (hitboxRotations.z > maxTilt) {
            hitboxRotations.z = maxTilt;
        } else if (hitboxRotations.z < -maxTilt) {
            hitboxRotations.z = -maxTilt;
        }
    }

    void rotateBackToUpright() {
        hitboxRotations = hitboxRotations.Round(1);
        // x axis
        if (hitboxRotations.x != 0f) {
            if (hitboxRotations.x < 0f) hitboxRotations.x += tiltReturnSpeed * Time.deltaTime;
            else hitboxRotations.x -= tiltReturnSpeed * Time.deltaTime;
        }

        // z axis
        if (hitboxRotations.z != 0f) {
            if (hitboxRotations.z < 0f) hitboxRotations.z += tiltReturnSpeed * Time.deltaTime;
            else hitboxRotations.z -= tiltReturnSpeed * Time.deltaTime;
        }

        // Set to zero if close (possibly floating point precision error?)
        if (hitboxRotations.x < 1f && hitboxRotations.x > -1f) hitboxRotations.x = 0f;
        if (hitboxRotations.z < 1f && hitboxRotations.z > -1f) hitboxRotations.z = 0f;
    }
    #endregion

    public void setJoystickHeld(bool b) {
        joystickHeld = b;
    }

    public void informFuelCollected() {
        fuelLevel = maxFuelLevel;
    }

}