using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

	[SerializeField]
	private Ship ship;

	[SerializeField]
	private Camera cam;
	public float speed;
	private float boost;
	private Transform trans;
	private Rigidbody2D rigid;
	private Animator anim;


	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
		trans = GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(ship.motor){
			Rotation();
		}
		else{
			StaticRotation();
		}
		Movement();
		Animador();
	}
	private void Movement(){
		Vector2 new_speed;
		if(ship.motor){
	 		new_speed = speed * trans.up;
		}
		else{
			new_speed = Vector2.zero;
		}
		rigid.velocity = Vector2.Lerp(rigid.velocity, new_speed, 0.5f);
	}

	private void Rotation(){

			float angle = Mathf.Atan2(-ship.direction.x, ship.direction.y) * Mathf.Rad2Deg;
			trans.rotation = Quaternion.Slerp(trans.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.2f);
			//flagelo.rotation = Quaternion.Slerp(flagelo.rotation, trans.rotation, 0.2f);

	}

	private void StaticRotation(){
		if(rigid.velocity.magnitude > 0.1f){
			float angle = Mathf.Atan2(-rigid.velocity.x, rigid.velocity.y) * Mathf.Rad2Deg;
			trans.rotation =  Quaternion.Slerp(trans.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.2f);
		}
	}

	private void Animador(){
		anim.SetFloat("velocity_tale", rigid.velocity.magnitude);
	}
	
}
