using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 60 * Time.deltaTime, 0, Space.Self);
    }

}
