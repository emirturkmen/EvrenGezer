    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_controller : MonoBehaviour
{

    
    public Transform upperLeftNozzle = null;
    public Transform upperRightNozzle = null;
    public Transform mainNozzle = null;

    [SerializeField]
    private Rigidbody2D rb = null;

    [SerializeField]
    private float upperNozzleForce = 0;


    private float dirX;

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        Vector3 upperForceDir = transform.right * dirX * upperNozzleForce;
        if (dirX > 0)
            rb.AddForceAtPosition(upperForceDir, upperLeftNozzle.position);
        else  if(dirX < 0)
            rb.AddForceAtPosition(upperForceDir, upperRightNozzle.position);


    }
}
