using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0, 0, 60 * Time.deltaTime, Space.Self);
    }

    public void OnTriggerEnter(Collider col)
    {
        gameObject.SetActive(false);
    }
}
