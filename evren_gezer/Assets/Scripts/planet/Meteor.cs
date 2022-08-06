using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Rigidbody rb;

    public float lifeTime = 3;

    private bool isCollided = false;

    private Vector3 rotateAngle;

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);
        isCollided = true;

        rotateAngle = new Vector3(Random.Range(-25, 25), Random.Range(-25, 25), Random.Range(-25, 25));
    }

    private void Update()
    {

        transform.Rotate(rotateAngle.x * Time.deltaTime, rotateAngle.y * Time.deltaTime, rotateAngle.z * Time.deltaTime, Space.Self);

        if (isCollided)
            lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
    }
}
