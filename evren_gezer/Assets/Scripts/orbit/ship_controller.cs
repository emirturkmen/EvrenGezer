using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_controller : MonoBehaviour
{
    public Transform mainNozzle = null;
    public float mainNozzleForce;
    public float rotationSensitivity;
    public float rotationSmoothTime;

    private Rigidbody2D rb = null;
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
