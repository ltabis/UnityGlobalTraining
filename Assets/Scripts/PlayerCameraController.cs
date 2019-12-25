using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    // Zoom parameters
    public float cameraZoomUpdateSpeed = -1f;
    public float maxZoomOutBoost = -20f;
    public float currentCameraZoom = 0f;
    public float maxZoomOutRegular = -70f;
    public float maxZoomInRegular = -40f;

    // Zoom bonus when boosting
    private float zoomAddition = 0;

    // Transform and controller script of the player
    private Transform bodyT;
    private PlayerController player;

    void Start()
    {
        // Get the transform component of the body
        bodyT = GameObject.Find("Body").GetComponent<Transform>();

        // Get a reference of the player
        player = GameObject.Find("Body").GetComponent<PlayerController>();

        // Initialize current camera zoom
        currentCameraZoom = maxZoomInRegular;
    }

    void Update()
    {
        // Copying the player's position
        transform.position = bodyT.position;

        // Check if the boost is activated, if so, incrementing maximum zooming out for the camera
        if (player.boostActivated)
        {
            zoomAddition = maxZoomOutBoost;
        }
        else
        {
            zoomAddition += zoomAddition < 0 ? 1 : 0;
        }

        // Update the camera zoom, the boost will affect the effect
        UpdateCameraZoom(Input.GetKey("up"), maxZoomOutRegular + zoomAddition, maxZoomInRegular);
    }

    private void UpdateCameraZoom(bool isKeyPressed, float maxZoomOut, float maxZoomIn)
    {
        // Updating the camera zoom
        currentCameraZoom += isKeyPressed ? cameraZoomUpdateSpeed : -cameraZoomUpdateSpeed;

        // Clamping the camera zoom between bounds
        currentCameraZoom = Mathf.Clamp(currentCameraZoom, maxZoomOut, maxZoomIn);

        // Updating the transform
        transform.position = new Vector3(transform.position.x, transform.position.y, currentCameraZoom);
    }
}
