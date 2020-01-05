using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 0.1f;
    private Transform target;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Body").transform;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }
}
