using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject Bolt;
    [SerializeField] private Transform Spawner;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        GameObject spawn = Instantiate(Bolt, Spawner.position, Spawner.rotation);
        spawn.transform.SetParent(gameObject.transform);
    }
}
