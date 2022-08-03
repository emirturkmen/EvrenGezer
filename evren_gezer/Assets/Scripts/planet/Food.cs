using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 60 * Time.deltaTime, 0, Space.Self);
    }

    public void OnTriggerEnter(Collider col)
    {
        GameObject fillBar = GameObject.FindWithTag("HealthBarFill");
        Bar_controller bar_controller = fillBar.GetComponent<Bar_controller>();
       
        bar_controller.increaseFillRate();
        gameObject.SetActive(false);
    }
}
