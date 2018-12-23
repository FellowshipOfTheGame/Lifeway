using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommanderTrigger : MonoBehaviour {

	[SerializeField] private CommanderActivator commanderActivator;
	[SerializeField] private string text;
	private float _time;
	[SerializeField] private float deltaTime;

	void Update(){
		_time += Time.deltaTime;
		if ((_time >= deltaTime) && Trigger()){
			commanderActivator.Activate(text);
			_time = 0f;
		}
	}

	protected abstract bool Trigger();

}
