using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

	public Transform player;
    public float delay, offset;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position - Vector3.forward * 10.0f + player.up * offset, delay);
	}
}
