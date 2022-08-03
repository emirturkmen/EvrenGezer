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
        
    }

    public void OnTriggerEnter(Collider col)
    {
        GameObject fillBar = GameObject.FindWithTag("HealthBarFill");
        Bar_controller bar_controller = fillBar.GetComponent<Bar_controller>();
       
        bar_controller.increaseFillRate();
        gameObject.SetActive(false);
    }
}
