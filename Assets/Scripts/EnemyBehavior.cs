using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    float range = 10f;
    //float speed = 0.1f;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 d = new Vector3(
            System.Math.Abs(transform.position.x - target.position.x),
            System.Math.Abs(transform.position.y - target.position.y),
            System.Math.Abs(transform.position.z - target.position.z)
        );

        Debug.Log(d.ToString());
        Debug.Log(target.ToString());
        if (d.x < range || d.y < range) {
            transform.Translate(new Vector3(1, 1));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
