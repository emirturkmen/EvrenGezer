using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider col)
    {
        GameObject fillBar = GameObject.FindWithTag("HealthBarFill");
        Bar_controller bar_controller = fillBar.GetComponent<Bar_controller>();
        bar_controller.decreaseFillRate();
        gameObject.SetActive(false);
    }
}
