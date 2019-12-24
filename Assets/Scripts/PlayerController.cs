using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float movementSpeed = 2f;

    private Rigidbody2D rb;

    private void Start()
    {
        // Store a reference to the rigidbody2D component of the object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Getting input from user (here it will be 0 or 1, but with a controller it will be bounded between 0 and 1)
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        
        // Applying transformations
        Thrust(y);
        RotateObject(transform, x * -rotationSpeed);

    }

    // Thrust the ship verticaly
    private void Thrust(float amout)
    {
        rb.AddForce(transform.up * amout * movementSpeed);
    }
    
    // Rotate the object with the x axis
    private void RotateObject(Transform t, float amout)
    {
        t.Rotate(0, 0, amout);
    }
}
