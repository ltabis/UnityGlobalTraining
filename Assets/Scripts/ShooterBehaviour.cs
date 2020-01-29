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
        Spawner = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        if (Bolt != null)
        {
            GameObject spawn = Instantiate(Bolt, Spawner.position, Spawner.rotation);
            spawn.transform.SetParent(gameObject.transform);
            spawn.GetComponent<BoltBehaviour>().direction = GameObject.Find("Body").GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;
        }
    }
}
