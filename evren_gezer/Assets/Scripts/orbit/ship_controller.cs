using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_controller : MonoBehaviour
{
    public float speed;
    public float rotationSensitivity;
    public float rotationSmoothTime;

    private Rigidbody2D rb = null;
    private Vector3 movement;
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;
    private float dirX;
    private float dirY;
    private float yaw;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
        if (dirY < 0)
            dirY = 0;
        Vector3 vertical = transform.up * dirY * speed;
        movement = new Vector3(0, 0, 0) + vertical;
    }

    private void FixedUpdate()
    {
        rb.velocity = movement;
    }

    private void LateUpdate()
    {
        yaw -= dirX * rotationSensitivity;

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(0, 0, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;
    }
}
