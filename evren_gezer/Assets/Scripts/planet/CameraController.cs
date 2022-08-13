using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Transform cameraPositionChild;

    private void Start()
    {
        cameraPositionChild = target.transform.Find("CameraPosition");
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, cameraPositionChild.position, 10 * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(target.rotation.x + 15f, 90f, 0f), 90 * Time.deltaTime);
    }
}
