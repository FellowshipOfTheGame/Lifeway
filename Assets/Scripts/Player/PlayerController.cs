using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Transform trans;
	private Rigidbody2D rigid;
	private Animator anim;
	[SerializeField]
	private Camera cam;
	[SerializeField]
	private float speed;
	[SerializeField]
	private float rotationSpeed;
	private bool motor;


	void Start () {
		trans = GetComponent<Transform>();
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		motor = false;
	}
	
	// Update is called once per frame
	void Update () {
		Motor(); // Turns the motor on and off, also controls the sperm's speed
		if (motor) { // You can't rotate with the motor off
			Rotation3(); // Rotates the sperm with the algorithm
			anim.SetFloat("Speed", 1f);
		}
		else {
			StaticRotation(); // Rotates the sperm according to the forces acting on it
			anim.SetFloat("Speed", 0f);
		}
	}

	// The sperm turns according to the forces acting on it
	private void StaticRotation(){
		// Verify if there is some velocity
		if (rigid.velocity.magnitude > 0.1f){
			// Adjusts the rotation
			float angle = Mathf.Atan2(-rigid.velocity.x, rigid.velocity.y) * Mathf.Rad2Deg;
			trans.rotation = Quaternion.Slerp(trans.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.1f);
		}
	}

	// Alg 1: The sperm turns according to the keyboard input, looking at it
	private void Rotation1(){
		// Get the input
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");
		// Verifies if it's not null
		if (Mathf.Abs(hor) >= 0.1f || Mathf.Abs(ver) >= 0.1f){
			// Then, adjusts the rotation
			float angle = Mathf.Atan2(-hor, ver) * Mathf.Rad2Deg;
			trans.rotation = Quaternion.Slerp(trans.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.1f);
		}
	}

	// Alg 2: The sperm only rotate based on the horizontal input (clockwise or counterclockwise)
	private void Rotation2(){
		// Get the horizontal input
		float hor = Input.GetAxis("Horizontal");
		// Rotate based on the input
		trans.rotation *= Quaternion.AngleAxis(-rotationSpeed * hor, Vector3.forward);
	}

	// Alg 3: The sperm looks directly to the mouse pointer position
	private void Rotation3(){
		// Get the mouse pointer position
		Vector3 pos = Input.mousePosition;
		pos = cam.ScreenToWorldPoint(pos) - trans.position;
		// Calculate the angle and rotate
		float angle = Mathf.Atan2(-pos.x, pos.y) * Mathf.Rad2Deg;
		trans.rotation = Quaternion.Slerp (trans.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.2f);
	}

	// Controls the motor
	private void Motor(){
		// Verifies if the motor state needs to be changed
		if (Input.GetMouseButtonDown(0)){
			motor = !motor;
		}
		// Set the sperm's speed
		rigid.velocity = Vector2.Lerp(rigid.velocity, (motor == true) ? (Vector2)trans.up * speed : Vector2.zero, 0.05f);
	}
}
