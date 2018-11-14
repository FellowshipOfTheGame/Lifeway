using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship {
		public ParticleSystem particles;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(energized){
			DirectionInput();
			MotorInput();
		}
	}

	private void DirectionInput(){
		var destiny = Input.mousePosition;
		destiny.z = 10;
		destiny = Camera.main.ScreenToWorldPoint(destiny);
		direction = destiny -  transform.position;
	}

	private void MotorInput(){
		if(Input.GetButtonDown("Fire1")){
			motor = true;
			PS.TurnOnMotor();
			particles.Play();
			ParticleSystem.MainModule aux = particles.main;
			aux.loop = true;
		}
		if(Input.GetButtonUp("Fire1")){
			motor = false;
			PS.TurnOffMotor();
			ParticleSystem.MainModule aux = particles.main;
			particles.Stop();
			aux.loop = false;
		}
	}
}
