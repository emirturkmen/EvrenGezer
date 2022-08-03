using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, 60 * Time.deltaTime, Space.Self);
    }

    public void OnTriggerEnter(Collider col)
    {
        GameObject fillBar = GameObject.FindWithTag("FuelBarFill");
        Bar_controller bar_controller = fillBar.GetComponent<Bar_controller>();
        bar_controller.increaseFillRate();
        gameObject.SetActive(false);
    }
}
