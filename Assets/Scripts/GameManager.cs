using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject gameOverScr;

	public LowEnergyTrigger energyTgr;
	public CamControl cam;
	public TextMeshProUGUI gameOverText;

	void Awake (){
		if(instance == null)
			instance = this;
		else
			Destroy(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowGameOver(string text){
		gameOverScr.SetActive(true);
		energyTgr.enabled = false;
		if(text != null && text != string.Empty)
			gameOverText.text = text;
	}
}
