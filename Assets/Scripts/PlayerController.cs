using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 360;
    public float movementSpeed = 20f;

    // Not yet used
    public float boostSpeed = 15f;
    public float boostDuration = 2f;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("boost"))
        {
            BoostThrust();
        }
        else
        {
            RegularThrust();
        }
        RotateObject();
    }

    // Thrust the object forward
    private void RegularThrust()
    {
        // Getting the velocity vector
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, 0);

        // Thrusting in the direction of the front of the object
        transform.position += transform.rotation * velocity;
    }

    // Boosts the ship forward
    private void BoostThrust()
    {
        // Not yet implemented
    }

    // Rotate the object on the z axis
    private void RotateObject()
    {
        // Getting z coordinate rotation
        float z = transform.rotation.eulerAngles.z;

        // Substracting horizontal abcissia
        z -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        // Updating transform
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
