using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

	public Area backArea, forwardArea;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log("colidiu");
		if(col.gameObject.tag == "Player"){
			if(Mathf.Abs(Vector3.Angle(col.transform.up, this.transform.up)) <= 90.0f){
				forwardArea.addPlayer(col.gameObject);
			}else{
				backArea.addPlayer(col.gameObject);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			if(Mathf.Abs(Vector3.Angle(col.transform.up, this.transform.up)) <= 90.0f){
				backArea.removePlayer(col.gameObject);
			}else{
				forwardArea.removePlayer(col.gameObject);
			}
		}
	}
}
