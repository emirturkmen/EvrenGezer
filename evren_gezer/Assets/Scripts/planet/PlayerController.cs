using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 4f;
	private Rigidbody rb;
	Vector3 groundNormal;
	private bool isGround;

	void Start(){
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
	}
	
	void Update() {
		float x = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
		float z = -Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
		transform.Translate(z,0,x);
		RaycastHit hit = new RaycastHit();
		if(Physics.Raycast(transform.position, -transform.up, out hit, 10)){
			float distanceGround = hit.distance;
			groundNormal = hit.normal;
			if(distanceGround <= 0.2f){
				isGround = true;
			}
			else{
				isGround = false;
			}
		}

		Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
		transform.rotation = toRotation;
	}

}