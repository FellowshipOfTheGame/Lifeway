using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

	public List<GameObject> players;
	public GameObject zone;

	// Use this for initialization
	void Start () {
		players = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addPlayer(GameObject p){
		if(players.Count == 0) zone.SetActive(true);
		players.Add(p);
	}

	public void removePlayer(GameObject p){
		players.Remove(p);
		if(players.Count == 0) zone.SetActive(false);
	}
}
