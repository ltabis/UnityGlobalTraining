using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement.
    public float rotationSpeed = 360f;
    public float normalMovementSpeed = 20f;
    public float maxVelocity = 40f;

    // Boost.
    public float boostFactor = 2f;
    public float boostDuration = 1f;
    public float boostCoolDown = 2f;
    public bool boostActivated = false;

    // Boost private fields.
    private float boostUseTime = 0f;
    private float boostCoolDownTime = 0f;

    // Current velocity filed.
    private float currentVelocity = 0f;

    // Trails.
    public TrailRenderer Engine1Trail;
    public TrailRenderer Engine2Trail;

    // Dash public
    public float dashSpeed = 3.0f;
    public float dashLength = 10.0f;

    // Dash
    bool dashing = false;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;


    private void Start()
    {
        currentVelocity = normalMovementSpeed;
    }

    private void Update()
    {
        // Checking the dash as been activated
        DashThrust();

        // Checking if the boost button as been pressed.
        if (boostActivated || (Input.GetAxis("Vertical") > 0 && boostCoolDownTime <= 0f && Input.GetButton("boost")))
        {
            // Increment speed.
            currentVelocity += currentVelocity < normalMovementSpeed * boostFactor ? .5f : 0;

            // Thrusting.
            UseBoost(currentVelocity);
        }
        else
        {
            // Decrement speed if the normal movement speed isn't yet reached.
            currentVelocity -= currentVelocity > normalMovementSpeed ? .5f : 0;
            boostCoolDownTime -= boostCoolDownTime > 0 ? Time.deltaTime : 0;

            // Thrusting.
            Thrust(currentVelocity);
        }

        // Changing trail length using the current speed of the object.
        float offset = Mathf.Lerp(0f, 5f, Input.GetAxis("Vertical") * (currentVelocity / maxVelocity));
        ChangeTrailWidth(offset);

        // Rotating the object.
        RotateObject(rotationSpeed);
    }

    // Thrust the object forward.
    private void Thrust(float speed)
    {
        // Getting the velocity vector.
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        // Thrusting in the direction of the front of the object.
        transform.position += transform.rotation * velocity;
    }

    // Rotate the object on the z axis.
    private void RotateObject(float speed)
    {
        // Getting z coordinate rotation.
        float z = transform.rotation.eulerAngles.z;

        // Substracting horizontal abcissia.
        z -= Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        // Updating transform.
        transform.rotation = Quaternion.Euler(0, 0, z);
    }

    private void UseBoost(float thrustPower)
    {
        if (boostUseTime < boostDuration)
        {
            // The boost is still active.
            // Getting the velocity vector.
            Vector3 velocity = new Vector3(0, thrustPower * Time.deltaTime, 0);

            // Thrusting in the direction of the front of the object.
            transform.position += transform.rotation * velocity;

            // Computing the usage time of the boost
            boostUseTime += Time.deltaTime;
            boostActivated = true;
        }
        else
        {
            // The boost as been consumed, desactivating it.
            boostActivated = false;
            boostUseTime = 0f;
            boostCoolDownTime = boostCoolDown;
        }
    }

    // Changes both engines trailes
    private void ChangeTrailWidth(float width)
    {
        // Setting the width of both trails.
        Engine1Trail.startWidth = width;
        Engine2Trail.startWidth = width;
        Engine1Trail.endWidth = width / 2;
        Engine2Trail.endWidth = width / 2;
    }

    // Thrusting in directions if the player hits 'd'
    private void DashThrust()
    {
        if (Input.GetButton("dash") && (Input.GetButton("left") || Input.GetButton("right")) && boostCoolDownTime <= 0)
        {
            // Getting the dash direction
            int direction = Input.GetButton("left") ? -1 : 1;

            // Reseting the timer
            boostCoolDownTime = boostCoolDown;

            // Setting values
            dashing = true;
            startPosition = transform.position;
            endPosition = transform.position + (transform.right * (dashLength * direction));
        }

        if (dashing)
        {
            // Move the player to the end position
            transform.position = Vector3.MoveTowards(transform.position, endPosition, dashSpeed);

            if (transform.position == endPosition)
            {
                dashing = false;
            }
        }
    }
}