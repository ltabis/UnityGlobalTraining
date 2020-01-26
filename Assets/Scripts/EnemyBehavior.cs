using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour, IEnemy
{
    private float speed = 0.1f;
    private float lifePoints = 10f;
    private Transform target;

    // Start is called before the first frame update
    private void Start() {}

    // Update is called once per frame
    private void Update()
    {
        target = GameObject.Find("Body").transform;
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }

    public float GetLifePoints()
    {
        return lifePoints;
    }

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
    }

    public void UpdateLifePoints(float amount)
    {
        lifePoints += amount;
    }
}
