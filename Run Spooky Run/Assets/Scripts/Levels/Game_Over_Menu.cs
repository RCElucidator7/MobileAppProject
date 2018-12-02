using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over_Menu : MonoBehaviour {

	public GameObject gameOverMenu;
	public int health_Check;
	public Player_Move pm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Set the local health to the characters health
		health_Check = pm.health;
		// Checks to see if the escape key is pressed
		if(health_Check == 0){
			GameOver();
		}	
	}

	// Function that sets the pause menu ingame to active and Sets the timescale to 0
	public void GameOver(){
		gameOverMenu.SetActive(true);
		Time.timeScale = 0f;
	}

	// Function that sets the pause menu ingame to inactive and resumes the timescale
	public void Restart(){
		gameOverMenu.SetActive(false);
		Time.timeScale = 1f;
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
		pm.health = 4;
	}

	// Function that is called when the Main Menu button is pressed in the pause menu.
	public void MainMenu(){
		//Resume the timescale for when the level is reloaded
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
		pm.health = 4;
	}
}
