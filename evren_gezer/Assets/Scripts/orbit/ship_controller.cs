using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_controller : MonoBehaviour
{
    public Transform mainNozzle = null;
    public float mainNozzleForce;
    public float rotationSensitivity;
    public float rotationSmoothTime;
    public float range;
    public float fireRate;
    public GameObject missile;
    public GameObject bullet;

    private Transform head;
    private Rigidbody2D rb = null;
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;
    private float dirX;
    private float dirY;
    private float yaw;
    private float nextFire;

    private void Start()
    {
        head = transform.Find("HeadOfRocket");
        rb = GetComponent<Rigidbody2D>();
        nextFire = Time.time;
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
        if (Input.GetKeyDown("space"))
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("EnemyShip");
            for (int i = 0; i < targets.Length; i++)
            {
                GameObject target = targets[i];
                if (Vector2.Distance(transform.position, target.transform.position) < range)
                {
                    GameObject instantiatedMissile = Instantiate(missile, transform.position, Quaternion.identity);
                    HomingMissile homingMissileScript = instantiatedMissile.GetComponent<HomingMissile>();
                    homingMissileScript.target = target.transform;
                    homingMissileScript.speed = 5;
                    homingMissileScript.rotateSpeed = 200;
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextFire)
            {
                Instantiate(bullet, head.position, Quaternion.identity).transform.up = transform.up;
                nextFire = Time.time + fireRate;
            }
        }

    }

    private void FixedUpdate()
    {
        Vector3 mainForceDir = transform.up * dirY * mainNozzleForce;
        if (dirY > 0)
        {
            rb.AddForceAtPosition(mainForceDir, mainNozzle.position);
        }
    }

    private void LateUpdate()
    {
        yaw -= dirX * rotationSensitivity;

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(0, 0, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;
    }
}
