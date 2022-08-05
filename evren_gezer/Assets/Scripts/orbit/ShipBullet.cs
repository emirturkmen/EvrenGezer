using UnityEngine;

public class ShipBullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    Rigidbody2D rb;

    GameObject target;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = transform.up.normalized * moveSpeed;
        transform.up = -1 * transform.up;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("EnemyShip"))
        {
            Destroy(gameObject);
        }
        else if (!collision.gameObject.tag.Equals("ship") && !collision.gameObject.tag.Equals("ShipBullet"))
        {
            Destroy(gameObject);
        }
    }
}
