using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuStart : MonoBehaviour {

	public void changeScene(string sceneName){
		//Application.LoadLevel(sceneName);
		SceneManager.LoadScene(sceneName);
	}
}
