using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCapsule : MonoBehaviour {

	[SerializeField]
	private float energy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other) {
		Energy e = other.gameObject.GetComponent<Energy>();
		if(e != null){ //checking if it is a ship
			e.AddEnergy(energy);
			Destroy(gameObject);
		}
	}
}
