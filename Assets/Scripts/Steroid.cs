using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steroid : Barrier_ {

	protected float HP;

	// Use this for initialization
	void Start () {
		HP = 5;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void KnockBack(GameObject player){
		HP--;
		if (HP <= 0) Break(player);
	}

	public virtual void Break(GameObject player){
		Destroy(this.gameObject);
	}
}
