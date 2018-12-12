using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowArea : MonoBehaviour {

	[SerializeField]
	private float friction;

	private void OnTriggerStay2D(Collider2D other){
		Motor motor = other.GetComponent<Motor>();
		if (motor != null){
			motor.GetSlowed(friction);
		}
	}

	private void OnTriggerExit2D(Collider2D other){
		Motor motor = other.GetComponent<Motor>();
		if (motor != null){
			motor.StopSlow();
		}
	}

}
