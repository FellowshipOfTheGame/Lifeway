using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

	[SerializeField]
	private AudioSource AS;
	[SerializeField]
	private AudioClip motorOn, motorTurnOn, motorTurnOff, motorDie;
	private Ship ship;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void TurnOnMotor(){
		AS.clip = motorTurnOn;
		AS.Play();
		Invoke("MotorOn", motorTurnOn.length);
		
	}

	private void MotorOn(){
		AS.Stop();
		AS.clip = motorOn;
		AS.Play();
		AS.loop = true;
	}

	public void TurnOffMotor(){
		CancelInvoke();
		AS.Stop();
		AS.clip = motorTurnOff;
		AS.Play();
		AS.loop = false;
		
	}

	public void MotorDie(){
		CancelInvoke();
		AS.Stop();
		AS.clip = motorDie;
		AS.Play();
		AS.loop = false;
	}
}
