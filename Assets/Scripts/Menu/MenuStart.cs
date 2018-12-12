using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour {

	[SerializeField]
	private AudioMixer audioMixer;
	[SerializeField]
	private Slider slider;

	public void ChangeScene(string sceneName){
		//Application.LoadLevel(sceneName);
		SceneManager.LoadScene(sceneName);
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void SetVolume(float volume){
		audioMixer.SetFloat("volume", volume);
	}

	public void RefreshVolumeSlider(){
		float value;
		audioMixer.GetFloat("volume", out value);
		slider.value = value;
	}

}
