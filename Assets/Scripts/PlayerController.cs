using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement
    public float rotationSpeed = 360f;
    public float normalMovementSpeed = 20f;
    public float maxVelocity = 40f;

    // Boost
    public float boostFactor = 2f;
    public float boostDuration = 1f;
    public float boostCoolDown = 2f;
    public bool boostActivated = false;

    // Boost private fields
    private float boostUseTime = 0f;
    private float boostCoolDownTime = 0f;

    // Current velocity filed
    private float currentVelocity = 0f;

    // Trails
    public TrailRenderer Engine1Trail;
    public TrailRenderer Engine2Trail;

    private void Start()
    {
        currentVelocity = normalMovementSpeed;
    }

    private void Update()
    {
        // Checking if the boost button as been pressed
        if (boostCoolDownTime <= 0f && (Input.GetButton("boost") || boostActivated))
        {
            currentVelocity += currentVelocity < normalMovementSpeed * boostFactor ? 0.5f : 0;
            UseBoost(currentVelocity);
        }
        else
        {
            currentVelocity -= currentVelocity > normalMovementSpeed ? 0.5f : 0;
            Thrust(currentVelocity);
            boostCoolDownTime -= boostCoolDownTime > 0 ? Time.deltaTime : 0;
        }

        // Changing trail length using the current speed of the object
        float offset = Mathf.Lerp(0f, 5f, Input.GetAxis("Vertical") * (currentVelocity / maxVelocity));
        changeTrailWidth(offset);

        // Rotating the object
        RotateObject(rotationSpeed);
    }

    // Thrust the object forward
    private void Thrust(float speed)
    {
        // Getting the velocity vector
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        // Thrusting in the direction of the front of the object
        transform.position += transform.rotation * velocity;
    }

    // Rotate the object on the z axis
    private void RotateObject(float speed)
    {
        // Getting z coordinate rotation
        float z = transform.rotation.eulerAngles.z;

        // Substracting horizontal abcissia
        z -= Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Updating transform
        transform.rotation = Quaternion.Euler(0, 0, z);
    }

    private void UseBoost(float thrustPower)
    {
        if (boostUseTime < boostDuration)
        {
            Thrust(thrustPower);
            boostUseTime += Time.deltaTime;
            boostActivated = true;
        }
        else
        {
            boostActivated = false;
            boostUseTime = 0f;
            boostCoolDownTime = boostCoolDown;
        }
    }

    private void changeTrailWidth(float width)
    {
        Engine1Trail.startWidth = width;
        Engine2Trail.startWidth = width;
        Engine1Trail.endWidth = width / 2;
        Engine2Trail.endWidth = width / 2;
    }
}