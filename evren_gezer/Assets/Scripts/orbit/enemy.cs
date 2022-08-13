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
    public GameObject enemyHealthPrefab;
    private GameObject healthBar;
    private Transform healthBarPos;
    public Camera cam;
    public int health = 100;
    public GameObject explosionEffect;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("ship");
        targetPos1 = transform.position;
        targetPos2 = transform.position + new Vector3(0, targetMoveDistance, 0);
        firstMove = true;
        nextFire = Time.time;
        healthBar = Instantiate(enemyHealthPrefab);
        healthBar.transform.SetParent(GameObject.Find("Canvas").transform, false);
        healthBarPos = transform.Find("HealthBarPos");
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(Instantiate(explosionEffect, transform.position, transform.rotation), 2f);
            Destroy(gameObject);
            Destroy(healthBar);
        }
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
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.transform.position) < range)
            {
                transform.up = target.transform.position - transform.position;
                CheckIfTimeToFire();
            }
        }
        healthBar.transform.position = cam.WorldToScreenPoint(healthBarPos.position);
    }


    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    public void ReduceHealth(int reduceAmount)
    {
        Bar_controller barScript = healthBar.gameObject.GetComponent<Bar_controller>();
        barScript.ReduceBar((float)reduceAmount / 100);
        health -= reduceAmount;
    }
}
