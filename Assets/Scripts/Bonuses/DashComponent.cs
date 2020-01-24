using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashComponent : MonoBehaviour, IBonus
{
    // Dash public fields
    public int dashAmout = 1;
    public int maxDashAmout = 3;
    public float dashSpeed = 3.0f;
    public float dashLength = 10.0f;
    public float dashCooldownTime = 3.0f;

    // Dash private fields
    private int dashsUsed = 0;
    private bool dashing = false;
    private Vector3 endPosition = Vector3.zero;
    private float coolDown = .0f;

    // Update is called once per frame
    void Update()
    {
        if (!dashing)
            SetDashDirection();
        DashThrust();
        CooldownTime();
    }

    private void SetDashDirection()
    {
        // Checking if buttons have been used
        if (Input.GetButton("dash") && (Input.GetButtonDown("left") || Input.GetButtonDown("right")) && dashsUsed < dashAmout)
        {
            // Getting the dash direction
            int direction = Input.GetButton("left") ? -1 : 1;

            // Setting values
            dashing = true;
            endPosition = transform.position + (transform.right * (dashLength * direction));
            dashsUsed += 1;
        }
    }

    // Thrusting in directions if the player hits 'd'
    private void DashThrust()
    {
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

    private void CooldownTime()
    {
        if (coolDown <= .0f)
        {
            coolDown = dashCooldownTime;
            dashsUsed -= dashsUsed != 0 ? 1 : 0;
        }
        else
        {
            coolDown -= Time.deltaTime;
        }
    }

    // Add a dash to the bonus
    public void Upgrade()
    {
        dashAmout += dashAmout < maxDashAmout ? 1 : 0;

        // Reseting dashs used.
        dashsUsed = 0;
    }
}
