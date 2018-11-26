using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

	public static bool GamePaused = false;
	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Checks to see if the escape key is pressed
		if(Input.GetKeyDown(KeyCode.Escape)){
			// If the game is already paused when excape is clicked then it resumes the game
			if(GamePaused){
				Resume();
			}
			// Pauses the game
			else{
				Pause();
			}
		}	
	}

	// Function that sets the pause menu ingame to active and Sets the timescale to 0
	public void Pause(){
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		GamePaused = true;
	}

	// Function that sets the pause menu ingame to inactive and resumes the timescale
	public void Resume(){
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		GamePaused = false;
	}

	// Function that is called when the Main Menu button is pressed in the pause menu.
	public void MainMenu(){
		//Resume the timescale for when the level is reloaded
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}
}
