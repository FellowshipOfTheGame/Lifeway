using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTrigger : CommanderTrigger {

	bool onWarning = false;

	protected override bool Trigger(){
		if(onWarning){
			onWarning = false;
			return true;
		}
		return false;
	}

	public void StartWarning(string text){
		this.text = text;
		onWarning = true;
		Invoke("Stop", 0.5f);
	}
}
