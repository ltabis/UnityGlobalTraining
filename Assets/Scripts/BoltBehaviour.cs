using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBehaviour : MonoBehaviour
{
    public float speed = 1.3f;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = speed * direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0);
    }
}
