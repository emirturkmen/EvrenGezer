using UnityEngine;

public class enemy : MonoBehaviour
{
    private Vector3 targetPos1;
    private Vector3 targetPos2;
    public GameObject bullet;
    private GameObject target;
    public float targetMoveDistance;
    public float speed = 1f;
    public float range;
    public float fireRate;
    private float nextFire;
    public bool canMove = true;
    public bool firstMove;

    void Start()
    {
        targetPos1 = transform.position;
        targetPos2 = transform.position + new Vector3(0, targetMoveDistance, 0);
        firstMove = true;
        nextFire = Time.time;
    }

    void Update()
    {
        if (transform.position == targetPos1)
        {
            firstMove = false;
        }
        if (transform.position == targetPos2)
        {
            firstMove = true;
        }
        if (canMove)
        {
            if (firstMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos1, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos2, speed * Time.deltaTime);
            }
        }
        target = GameObject.FindGameObjectWithTag("ship");
        if (Vector2.Distance(transform.position, target.transform.position) < range)
        {
            transform.up = target.transform.position - transform.position;
            CheckIfTimeToFire();
        }
    }


    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
