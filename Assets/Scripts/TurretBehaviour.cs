using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    [SerializeField] private float time = 0.0f;
    [SerializeField] private float gap = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= gap)
        {
            time = time - gap;
            gameObject.GetComponentInChildren<ShooterBehaviour>().Shoot();
        }
    }
}
