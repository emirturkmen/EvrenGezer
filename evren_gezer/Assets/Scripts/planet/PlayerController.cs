using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 4f;
	private Rigidbody rb;
	Vector3 groundNormal;
	private bool isGround;
	public Animator anim;
	public float allowPlayerRotation = 0.1f;

	void Start(){
		anim = this.GetComponent<Animator> ();
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
	}
	
	void Update() {
		float Speed = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).sqrMagnitude;
		if (Speed > allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, 0.3f, Time.deltaTime);
			float x = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
			float z = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
			transform.Translate(x,0,z);
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
		} else if (Speed < allowPlayerRotation) {
			anim.SetFloat ("Blend", Speed, 0.15f, Time.deltaTime);
		}
		
	}
}
