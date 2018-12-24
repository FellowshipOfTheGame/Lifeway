using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCapsule : MonoBehaviour {

	[SerializeField]
	private float energy;
	[SerializeField]
	private AudioSource AS;
	[SerializeField]
	private SpriteRenderer SR;

	void OnTriggerEnter2D(Collider2D other) {
		Energy e = other.gameObject.GetComponent<Energy>();
		if(e != null){ //checking if it is a ship
			AS.Play();
			e.AddEnergy(energy);
			SR.enabled = false;
			Destroy(gameObject, AS.clip.length);
		}
	}
}
