using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

	public Area backArea, forwardArea;

	// Use this for initialization
	void Awake () {
		backArea.gates.Add(this);
		forwardArea.gates.Add(this);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			if(Mathf.Abs(Vector3.Angle(col.transform.up, this.transform.up)) <= 90.0f){
				forwardArea.addPlayer(col.gameObject, this);
			}else{
				backArea.addPlayer(col.gameObject, this);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		Debug.Log("Vanish");
		if(col.gameObject.tag == "Player"){
			if(Mathf.Abs(Vector3.Angle(col.transform.up, this.transform.up)) <= 90.0f){
				backArea.removePlayer(col.gameObject, this);
			}else{
				forwardArea.removePlayer(col.gameObject, this);
			}
		}
	}
}
