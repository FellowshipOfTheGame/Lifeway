using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpermBehaviour : MonoBehaviour {

	Rigidbody2D myRigid;
	private Vector3 destiny;

	private Transform trans;
	[SerializeField]
	private Transform flagelo;

	public float speed = 10f;
	//public GameObject ship;

	private Animator anim;
	private AudioSource AS;


	// Use this for initialization
	void Start () 
	{
		trans = GetComponent<Transform>();
		myRigid = GetComponent<Rigidbody2D>();
		myRigid.velocity = new Vector2 (1f,1f);
		anim = GetComponentInChildren<Animator>();
		AS = GetComponent<AudioSource>();
	}

	
	// Update is called once per frame
	void Update () {

		if(Motor()){
			Rotation();
			if(!AS.isPlaying){
				AS.Play();
			}
		}
		else{
			StaticRotation();
			AS.Stop();
		}
		Movement();
		Animador();

	}


	private void Movement(){
		Vector2 new_speed;
		if(Motor()){
	 		new_speed = speed * trans.up;
		}
		else{
			new_speed = Vector2.zero;
		}
		myRigid.velocity = Vector2.Lerp(myRigid.velocity, new_speed, 0.5f);
	}

	private void Rotation(){
		if(Motor()){
			destiny = Input.mousePosition;
 			destiny.z = 10;
 			destiny = Camera.main.ScreenToWorldPoint(destiny);
			Vector3 dir = destiny -  transform.position;

			float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg;
			trans.rotation = Quaternion.Slerp(trans.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.2f);
			//flagelo.rotation = Quaternion.Slerp(flagelo.rotation, trans.rotation, 0.2f);

		}
	}

	private void StaticRotation(){
		if(myRigid.velocity.magnitude > 0.1f){
			float angle = Mathf.Atan2(-myRigid.velocity.x, myRigid.velocity.y) * Mathf.Rad2Deg;
			trans.rotation =  Quaternion.Slerp(trans.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.2f);
		}
	}

	private bool Motor(){
		return Input.GetButton("Fire1");
	}

	private void Animador(){
		anim.SetFloat("velocity_tale", myRigid.velocity.magnitude);
	}
}

