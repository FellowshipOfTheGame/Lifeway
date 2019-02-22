using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {

	[HideInInspector] public List<GameObject> players;
	public GameObject zone;
	[HideInInspector] public List<Gate> gates;

	// Use this for initialization
	void Start () {
		players = new List<GameObject>();
		if (GameManager.instance.firstArea != null){
			zone.SetActive(false);
				foreach (Gate gate in gates){
						gate.gameObject.SetActive(false);
				}

			if(GameManager.instance.firstArea == this){
				zone.SetActive(true);
				foreach (Gate gate in gates){
						gate.gameObject.SetActive(true);
						Debug.Log(gate.name);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addPlayer(GameObject p, Gate g){
		if(players.Count == 0){
			zone.SetActive(true);
			foreach (Gate gate in gates){
				if(gate != g) 
					gate.gameObject.SetActive(true);
			}
		}
		players.Add(p);
	}

	public void removePlayer(GameObject p, Gate g){
		players.Remove(p);
		if(players.Count == 0){
			zone.SetActive(false);
			foreach (Gate gate in gates){
				if(gate != g) 
					gate.gameObject.SetActive(false);
			}
		}
	}
}
