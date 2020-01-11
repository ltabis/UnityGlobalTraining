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

    // Shake coroutine
    public Shake shakeEffect;

    // Zoom bonus when boosting
    private float zoomAddition = 0;

    // Boost.
    private bool boostActivated = false;

    // Transform and controller script of the player
    private Transform bodyT;

    void Start()
    {
        // Get the transform component of the body
        bodyT = GameObject.Find("Body").GetComponent<Transform>();

        // Initialize current camera zoom
        currentCameraZoom = maxZoomInRegular;
    }

    void Update()
    {
        // Copying the player's position
        transform.position = bodyT.position;

        // Check if the boost is activated, if so, incrementing maximum zooming out for the camera
        if (boostActivated)
        {
            zoomAddition = maxZoomOutBoost;
            StartCoroutine(shakeEffect.ShakeOnce(.4f, .2f));
        }
        else
        {
            zoomAddition += zoomAddition < 0 ? 1 : 0;
        }

        // Update the camera zoom, the boost will affect the effect
        UpdateCameraZoom(Input.GetKey("up"), maxZoomOutRegular + zoomAddition, maxZoomInRegular);
    }

    public void BoostEffects(bool status)
    {
        boostActivated = status;
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

