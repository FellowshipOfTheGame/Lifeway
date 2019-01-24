using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbo : MonoBehaviour {

	Motor motor;
	float normalSpd;
	public float boostSpd;
	public float turboSpd;
	public float boostTime;

	// Use this for initialization
	void Start () {
		motor = this.GetComponent<Motor>();
		normalSpd = motor.speed;
	}

	public void ActivateBoost(){
		motor.speed = boostSpd;
		Invoke("StopBoost", boostTime);
	}

	void StopBoost(){
		motor.speed = normalSpd;
	}

	public void ActivateTurbo(){
		motor.speed = turboSpd;
	}
}