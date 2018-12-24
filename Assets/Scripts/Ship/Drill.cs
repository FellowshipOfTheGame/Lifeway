using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour {

	public bool canDrill;
	int count;
	public float step;
	public Ship ship;
	public Ovulus ovulus;

	// Use this for initialization
	void Start () {
		count = 0;
		canDrill = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (canDrill && Input.GetMouseButtonDown(0) && count < ovulus.limit){
			count++;
			this.transform.position += this.transform.up * step * Time.deltaTime;
			if(count >= ovulus.limit) ovulus.CheckVictory(ship);
		}
	}
}
