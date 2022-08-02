using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreator : MonoBehaviour
{

    public float distance;
    public float rate;
    public float speed;

    public bool spawnMeteor = false;

    private float timeSinceLastMeteor = 0;

    public GameObject meteor;
    

    private void Update()
    {
        timeSinceLastMeteor += Time.deltaTime;

        if(timeSinceLastMeteor >= 1 / rate && spawnMeteor)
        {
            instantiateMeteor();
            timeSinceLastMeteor = 0f;
        }
    }

    public Vector3 instantiateMeteor()
    {
        Vector3 dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * distance;

        Vector3 spawn_pos = dir + transform.position;

        Vector3 velocity_dir = (-dir).normalized;



        GameObject meteor_object = Instantiate(meteor, spawn_pos, Quaternion.identity);
        meteor_object.GetComponent<Rigidbody>().velocity = velocity_dir * speed;

        return spawn_pos;
    }

}
