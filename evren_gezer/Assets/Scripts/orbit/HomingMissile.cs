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
    public orbitcontroller orbitController;

    void Start()
    {
        orbitController = GameObject.Find("Manager").GetComponent<orbitcontroller>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(target == null)
        {
            Destroy(gameObject);
        }
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
            orbitController.gameController.GetComponent<AudioManager>().playSound("RocketBomb");
            enemy enemyScript = collision.gameObject.GetComponent<enemy>();
            enemyScript.health = 0;
            Destroy(Instantiate(explosionEffect, transform.position, transform.rotation), 2f);
            Destroy(gameObject);
        } else if (!collision.gameObject.tag.Equals("ship") && !collision.gameObject.tag.Equals("Rocket"))
        {
            Destroy(gameObject);
        }
    }
}
