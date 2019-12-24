using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 180f;
    public float movementSpeed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        // Store a reference to the rigidbody2D component of the object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Thrust();
        RotateObject();
    }

    // Thrust the ship verticaly
    private void Thrust()
    {
        // Getting the velocity vector
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, 0);

        // Thrusting in the direction of the front of the object
        transform.position += transform.rotation * velocity;
    }

    // Rotate the object with the x axis
    private void RotateObject()
    {
        // Getting z rotation
        float z = transform.rotation.eulerAngles.z;

        // Substracting horizontal abcissia
        z -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        // Updating transform
        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}
