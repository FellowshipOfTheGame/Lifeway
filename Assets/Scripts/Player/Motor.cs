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
	private float flush;
	[SerializeField]
	private Transform trans;
	[SerializeField]
	private Rigidbody2D rigid;
	private bool hit;
	[SerializeField]
	private Energy energy;
	[SerializeField]
	private PlayerAnimation PA;


	// Use this for initialization
	void Start () {
		hit = false;
		flush = 1f;		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!hit){
			if(ship.motor){
				Rotation();
			}
			else{
				StaticRotation();
			}
			Movement();
		}
		PA.Animador(rigid.velocity.magnitude);
	}
	private void Movement(){
		Vector2 new_speed;
		if(ship.motor){
	 		new_speed = speed * flush * trans.up;
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
	
	public void KnockBack(float e) {
		hit = true;
		Invoke("CanMove", 0.11f);
		energy.DecreaseEnergy(e);
	}

	private void CanMove(){
		hit = false;
	}

	public void GetSlowed(float newFlush){
		flush = newFlush;
	}

	public void StopSlow(){
		flush = 1f;
	}

}
