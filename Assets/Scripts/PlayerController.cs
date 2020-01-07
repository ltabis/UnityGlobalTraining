using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement.
    public float normalMovementSpeed = 20f;
    public float currentVelocity = 0f;
    public float rotationSpeed = 360f;
    public float maxVelocity = 40f;

    // Trails.
    public TrailRenderer Engine1Trail;
    public TrailRenderer Engine2Trail;

    private void Start()
    {
        currentVelocity = normalMovementSpeed;
    }

    private void Update()
    {
        // Thrusting.
        Thrust(currentVelocity);
        
        // Changing trail length using the current speed of the object.
        float offset = Mathf.Lerp(0f, 5f, Input.GetAxis("Vertical") * (currentVelocity / maxVelocity));
        ChangeTrailWidth(offset);

        // Rotating the object.
        RotateObject(rotationSpeed);
        if (Input.GetKeyUp("space") && GameObject.Find("Clock").GetComponent<Timer>().IsEnd())
        {
            Shoot();
        }
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

    // Check if a bonus as been hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bonus"))
        {
            MonoBehaviour[] scriptList = collision.gameObject.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour script in scriptList)
            {
                if (gameObject.GetComponent(script.GetType()) != null)
                    gameObject.GetComponent<IBonus>().Upgrade();
                else if (script.name != "BonusBehaviour")
                    gameObject.AddComponent(script.GetType());
            }
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

    private void Shoot()
    {
        Debug.Log("Shoot !");
    }
}