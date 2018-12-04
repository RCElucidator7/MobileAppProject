using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Navigation : MonoBehaviour {

	public GameObject options;
	public GameObject mainMenu;
	public bool audioCheck = true;

	public void playGame () {
		SceneManager.LoadScene("LevelSelectMenu");
	}

	public void quitOption () {
		Debug.Log("Quitting Application");
		Application.Quit();
	}

	public void optionsMenu(){
		mainMenu.SetActive(false);
		options.SetActive(true);
	}

	public void toggleMusic(){
		audioCheck = !audioCheck;
		if(audioCheck){
			AudioListener.pause = true;
		}
		else{
			AudioListener.pause = false;
		}
	}

	public void toggleFullscreen(){
		Debug.Log("Fullscreen Toggled");
		Screen.fullScreen = !Screen.fullScreen;
	}

	public void backButton(){
		options.SetActive(false);
		mainMenu.SetActive(true);
	}
}
