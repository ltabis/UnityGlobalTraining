using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBody : MonoBehaviour
{
    private Transform bodyT;

    void Start()
    {
        // Get the transform component of the body
        bodyT = GameObject.Find("Body").GetComponent<Transform>();
    }

    void Update()
    {
        // Use the transform of the body, but not the z coordinate.
        transform.position = new Vector3(bodyT.position.x, bodyT.position.y, transform.position.z);
    }
}
