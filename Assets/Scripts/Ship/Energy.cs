﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour {

	private float currentEnergy;
	[SerializeField]
	private float maxEnergy;
	[SerializeField]
	private float deltaEnergy;
	public Image eBar;
	
	[SerializeField]
	private Ship ship;
	//public GameObject loserText, backButton;

	// Use this for initialization
	void Start () {
		currentEnergy = maxEnergy;
		//loserText.SetActive(false);
		//backButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(ship.motor){
			DecreaseEnergy(deltaEnergy * Time.deltaTime);
		}
		//Debug.Log(currentEnergy);
		eBar.fillAmount = currentEnergy/maxEnergy;

	}
	public void AddEnergy(float e){
		currentEnergy += e;
		if (currentEnergy > maxEnergy){
			currentEnergy = maxEnergy;
		}
	}

	public void DecreaseEnergy(float e){
		currentEnergy -= e;
		if(currentEnergy <= 0){
			currentEnergy = 0;
			//loserText.SetActive(true);
			//backButton.SetActive(true);
			Debug.Log("FALICEU");
			ship.MotorDie();
		}
	}

	public bool LowEnergy(){
		return (currentEnergy/maxEnergy <= .1f);
	}
}
