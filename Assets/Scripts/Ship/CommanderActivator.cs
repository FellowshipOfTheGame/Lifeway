using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommanderActivator : MonoBehaviour {

	[SerializeField]
	private Animator commanderAnimator;
	[SerializeField]
	private TextMeshProUGUI commanderTextField;

	public void Activate(string text){
		commanderTextField.text = text;
		commanderAnimator.SetTrigger("Appear");
	}

}
