using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject bullet;
    public float range;
    GameObject target;

    public float fireRate;
    float nextFire;

    void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    void Update()
    {
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
