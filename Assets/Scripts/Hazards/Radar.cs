using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

	public Energy target = null;

	void OnTriggerEnter2D(Collider2D col){
		if(target == null)
			target = col.GetComponent<Energy>();
	}

	void OnTriggerExit2D(Collider2D col){
		if (target != null && target == col.GetComponent<Energy>())
			target = null;
	}
}
