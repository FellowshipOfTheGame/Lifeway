using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowEnergyTrigger : CommanderTrigger {

	[SerializeField]
	private Energy energy;

	protected override bool Trigger(){
		return energy.LowEnergy();
	}

}
