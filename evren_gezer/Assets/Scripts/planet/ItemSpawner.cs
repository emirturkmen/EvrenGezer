using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject food;
    public GameObject fuel;
    public GameObject obstacle;
    private int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        for ( ;a <5; a++) 
            {
                spawnItems(food);
                spawnItems(fuel);
                spawnItems(obstacle);
            }
    }
    void Update()
    {
        
    }

    private void spawnItems(GameObject item)
        {
            float radius = 5f;
            Vector3 spawnPosition = Random.onUnitSphere * (radius) + transform.position;
            GameObject newObj = Instantiate(item, spawnPosition, Quaternion.identity) as GameObject;
            newObj.transform.LookAt(transform.position);
            if(newObj.tag != "Fuel")
                newObj.transform.Rotate(-90, 0, 0);
        }
}
