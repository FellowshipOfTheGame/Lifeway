using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovulus : Steroid {

	Collider2D protection;
	public int limit;
	Ship winner = null;
	public GameObject click, winnerText, backButton;

	// Use this for initialization
	void Start () {
		HP = 10;
		protection = this.GetComponent<Collider2D>();
		click.SetActive(false);
		winnerText.SetActive(false);
		backButton.SetActive(false);
	}

	public override void Break(GameObject player){
		protection.enabled = false;
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			Ship control = col.GetComponent<Ship>();
			control.motor = false;
			control.enabled = false;
			control.Silence();
			Debug.Log("DRILL!!!");
			/* 
			control.drill.ovulus = this;
			control.drill.canDrill = true;
			*/
			Drill drill = col.GetComponent<Drill>();
			drill.ovulus = this;
			drill.canDrill = true;
			click.SetActive(true);
		}
	}

	public void CheckVictory(Ship s){
		if(winner == null){
			winner = s;
			winnerText.SetActive(true);
			click.SetActive(false);
			Debug.Log("WINNER!!!");
			backButton.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update () {
		if (winner != null) 
			winner.transform.position = Vector3.Lerp(winner.transform.position, this.transform.position, 0.05f);
	}
}
