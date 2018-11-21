using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {
	[SerializeField]
	private float energyLoss;

	void OnCollisionEnter2D(Collision2D other) {
		Motor m = other.gameObject.GetComponent<Motor>();
		if (m != null){
			m.KnockBack(energyLoss);
		}
	}

}
