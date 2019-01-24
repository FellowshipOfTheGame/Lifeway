using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Radar radar;

	public float spd;
	public float chaseSpd;

	Animator animator;

	public string killText;

	bool chasing = false, killing = false, capturing = false;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!killing){
			if(radar.target != null && radar.target.LowEnergy()){
				chasing = true;
				Chase(radar.target.transform.position);
			}else{
				chasing = false;
				Move();
			}
			animator.SetBool("chasing",chasing);
		}else{
			if(capturing)
				Capture();
		}
	}

	void Chase(Vector3 destiny){
		Vector3 direction = (destiny - this.transform.position).normalized;
		this.transform.up = Vector3.Lerp(this.transform.up, direction, 0.15f);
		this.transform.position += this.transform.up * chaseSpd * Time.deltaTime;
	}

	void Move(){
		this.transform.position += this.transform.up * spd * Time.deltaTime;
	}

	void Capture(){
		radar.target.transform.up = Vector3.Lerp(radar.target.transform.up, -this.transform.up, 0.6f);
		radar.target.transform.position = Vector3.Lerp(radar.target.transform.position, this.transform.position, 0.3f);
	}

	void Kill(){
		if(radar.target.gameObject.tag == "Player"){
			GameManager.instance.ShowGameOver(killText);
			radar.target.gameObject.SetActive(false);
		}else
			Destroy(radar.target.gameObject);

		radar.target = null;
		capturing = false;
		killing = false;
	}
	void OnTriggerEnter2D(Collider2D col){
		if(radar.target != null && radar.target.gameObject == col.gameObject){
			radar.target.GetComponent<Motor>().speed = 0.0f;
			col.enabled = false;
			killing = true;
			animator.SetTrigger("kill");
			GameManager.instance.cam.Freeze();
			Invoke("Eat", 0.7f);
			Invoke("Kill", 1.0f);
		}
	}

	void Eat(){
		capturing = true;
	}

}
