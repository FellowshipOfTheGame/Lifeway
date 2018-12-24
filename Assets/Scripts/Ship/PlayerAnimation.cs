using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	[SerializeField]
	private Animator anim;
	[SerializeField]
	private ParticleSystem particles;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Animador(float vel){
		anim.SetFloat("velocity_tale", vel);
	}

	public void Die(){
		anim.enabled = false;
		DeactivateParticles();
	}

	public void ActivateParticles(){
		particles.Play();
		ParticleSystem.MainModule aux = particles.main;
		aux.loop = true;
	}

	public void DeactivateParticles(){
		ParticleSystem.MainModule aux = particles.main;
		particles.Stop();
		aux.loop = false;
	}
}
