using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBehaviour : MonoBehaviour
{
    public Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
