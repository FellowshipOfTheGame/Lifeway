using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	private float currentEnergy;
	[SerializeField]
	private float maxEnergy;
	[SerializeField]
	private float deltaEnergy;
	
	[SerializeField]
	private Ship ship;

	// Use this for initialization
	void Start () {
		currentEnergy = maxEnergy;

	}
	
	// Update is called once per frame
	void Update () {
		if(ship.motor){
			DecreaseEnergy(deltaEnergy * Time.deltaTime);
		}
		Debug.Log(currentEnergy);


	}
	public void AddEnergy(float e){
		currentEnergy += e;
		if (currentEnergy > maxEnergy){
			currentEnergy = maxEnergy;
		}
	}

	private void DecreaseEnergy(float e){
		currentEnergy -= e;
		if(currentEnergy <= 0){
			currentEnergy = 0;
			ship.MotorDie();
		}
	}
}
