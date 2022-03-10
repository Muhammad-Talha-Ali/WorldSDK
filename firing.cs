using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform helicopter;
    Rigidbody instantiatedProjectile;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             instantiatedProjectile = Instantiate(bullet,helicopter.position,transform.rotation)  as Rigidbody;

            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

          

        }
        Destroy(instantiatedProjectile, 2f);
    }
}
