using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float maxZoomOut = -70f;
    public float maxZoomIn = -40f;
    public float currentCameraZoom;
    public float cameraZoomUpdateSpeed = -1f;

    private Transform bodyT;

    void Start()
    {
        // Get the transform component of the body
        bodyT = GameObject.Find("Body").GetComponent<Transform>();

        // Initialize current camera zoom
        currentCameraZoom = maxZoomIn;
    }

    void Update()
    {
        // Use the transform of the body, but not the z coordinate.
        transform.position = new Vector3(bodyT.position.x, bodyT.position.y, transform.position.z);

        // Update the camera zoom
        UpdateCameraZoom(Input.GetKey("up"));
    }

    private void UpdateCameraZoom(bool isKeyPressed)
    {

        // Updating the camera zoom
        currentCameraZoom += isKeyPressed ? cameraZoomUpdateSpeed : -cameraZoomUpdateSpeed;

        Debug.Log("Zoom: " + currentCameraZoom);
        // Clamping the camera zoom between bounds
        currentCameraZoom = Mathf.Clamp(currentCameraZoom, maxZoomOut, maxZoomIn);

        // Updating the transform
        transform.position = new Vector3(transform.position.x, transform.position.y, currentCameraZoom);
    }
}
