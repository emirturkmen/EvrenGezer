using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    Rigidbody2D rb;

    GameObject target;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("ship");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        transform.up = -1 * (target.transform.position - transform.position);
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ship"))
        {
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
