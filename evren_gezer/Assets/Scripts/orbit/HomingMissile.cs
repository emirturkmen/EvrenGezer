using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float rotateSpeed;
    private Rigidbody2D rb;
    public GameObject explosionEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(speed);
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyShip"))
        {
            Destroy(Instantiate(explosionEffect, transform.position, transform.rotation), 2f);
            Destroy(gameObject);
        } else if (!collision.gameObject.tag.Equals("ship") && !collision.gameObject.tag.Equals("Rocket"))
        {
            Destroy(gameObject);
        }
    }
}
