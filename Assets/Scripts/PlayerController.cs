using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 10f;
    public float speedBonus = 1f;
    private new Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("left"))
        {
            transform.Translate(Vector3.left * baseSpeed * speedBonus * Time.deltaTime);
        }
        if (Input.GetButton("right"))
        {
            transform.Translate(Vector3.right * baseSpeed * speedBonus * Time.deltaTime);
        }
        if (Input.GetButton("up"))
        {
            transform.Translate(Vector3.up * baseSpeed * speedBonus * Time.deltaTime);
        }
        if (Input.GetButton("down"))
        {
            transform.Translate(Vector3.down * baseSpeed * speedBonus * Time.deltaTime);
        }
    }
}
