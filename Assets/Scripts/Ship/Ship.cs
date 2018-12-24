using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	private int count;
	public bool motor;
	public Vector2 direction;
	private bool arrive;
	public bool energized;
	[SerializeField]
	protected PlayerSound PS;
	[SerializeField]
	protected PlayerAnimation PA;

	// Use this for initialization
	void Start () {
		energized = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MotorDie(){
		energized = false;
		motor = false;
		PS.MotorDie();
		PA.Die();
	}

	public void Silence(){
		PS.enabled = false;
	}
	

}
