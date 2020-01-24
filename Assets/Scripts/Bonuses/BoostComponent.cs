using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostComponent : MonoBehaviour, IBonus
{
    // Boost.
    public float boostFactor = 2.0f;
    public float boostDuration = 1.0f;
    public float boostCoolDown = 2.0f;
    public bool boostActivated = false;

    // Bonus.
    public float boostBonus = .5f;

    // Boost private fields.
    private float boostUseTime = 0f;
    private float boostCoolDownTime = 0f;

    private PlayerController player;
    private PlayerCameraController playerCamera;

    private void Start()
    {
        // Get a reference of the player
        player = GameObject.Find("Body").GetComponent<PlayerController>();

        // Get a reference of the player
        playerCamera = GameObject.Find("PlayerCamera").GetComponent<PlayerCameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if the boost button as been pressed.
        if (boostActivated || (Input.GetAxis("Vertical") > 0 && boostCoolDownTime <= 0f && Input.GetButton("boost")))
        {
            // Increment speed.
            player.currentVelocity += player.currentVelocity < player.normalMovementSpeed * boostFactor ? .5f : 0;

            // Thrusting.
            UseBoost(player.currentVelocity);
        }
        else
        {
            // Decrement speed if the normal movement speed isn't yet reached.
            player.currentVelocity -= player.currentVelocity > player.normalMovementSpeed ? .5f : 0;
            boostCoolDownTime -= boostCoolDownTime > 0 ? Time.deltaTime : 0;
        }
    }

    private void UseBoost(float thrustPower)
    {
        // The boost is still active.
        if (boostUseTime < boostDuration)
        {
            // Getting the velocity vector.
            Vector3 velocity = new Vector3(0, thrustPower * Time.deltaTime, 0);

            // Thrusting in the direction of the front of the object.
            transform.position += transform.rotation * velocity;

            // Computing the usage time of the boost
            boostUseTime += Time.deltaTime;
            boostActivated = true;
            
            // Effects on camera
            playerCamera.BoostEffects(true);

        }
        else
        {
            // The boost as been consumed, desactivating it.
            boostActivated = false;
            boostUseTime = 0f;
            boostCoolDownTime = boostCoolDown;

            // Disable camera boost effects.
            playerCamera.BoostEffects(false);
        }
    }

    // Upgrade the boost time
    public void Upgrade()
    {
        boostCoolDown -= boostCoolDown > 0 ? boostBonus : 0;

        // Reseting cool down time.
        boostCoolDownTime = .0f;
    }
}