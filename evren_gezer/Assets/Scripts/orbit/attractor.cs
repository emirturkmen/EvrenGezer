using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractor : MonoBehaviour
{

    public Rigidbody2D rb = null;
    public float forceMultiplier = 0;
    private Rigidbody2D shipRb = null;

    private void Start()
    {
        GameObject shipObj = GameObject.FindGameObjectWithTag("ship");
        shipRb = shipObj.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Vector3 gravity =  calcGravity();
        shipRb.AddForce(gravity);
    }


    Vector3 calcGravity()
    {
        Vector3 direction = rb.position - shipRb.position;
        float distance = direction.magnitude;
        float forceMagnitude = (rb.mass * shipRb.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;
        return force * forceMultiplier;
    }
}
