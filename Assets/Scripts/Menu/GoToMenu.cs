using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour {

	public void BackToMenu(){
		//Application.LoadLevel(sceneName);
		SceneManager.LoadScene("MainMenu");
	}

}
