using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

	//Audiocheck for game music
	public bool audioCheck = true;
	public static bool GamePaused = false;
	public GameObject pauseMenu;
	public GameObject optionsMenu;
	public GameObject highScoreMenu;
	//Variables to store the scores locally
	public int[] scores = new int[5];
	public int score5;
	//Game objects to access the level scores on the high score menu
	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	public GameObject level4;
	public GameObject level5;

	// Use this for initialization
	void Start () {
		//Get the scores from the PlayerPrefs and assign them to high score variables
		scores[0] = PlayerPrefs.GetInt ("highScore1", 0);
		scores[1] = PlayerPrefs.GetInt ("highScore2", 0);
		scores[2] = PlayerPrefs.GetInt ("highScore3", 0);
		scores[3] = PlayerPrefs.GetInt ("highScore4", 0);
		//Having an issue with the 5th position in the array so storing in a single variable
		score5 = PlayerPrefs.GetInt ("highScore5", 0);
	}
	
	// Update is called once per frame
	void Update () {

		//Access the level game objects in the high score menu and display the scores
		level1.gameObject.GetComponent<Text>().text = ("Level 1: " + scores[0]);
		level2.gameObject.GetComponent<Text>().text = ("Level 2: " + scores[1]);
		level3.gameObject.GetComponent<Text>().text = ("Level 3: " + scores[2]);
		level4.gameObject.GetComponent<Text>().text = ("Level 4: " + scores[3]);
		//Having an issue with the 5th position in the array so storing in a single variable
		level5.gameObject.GetComponent<Text>().text = ("Level 5: " + score5);

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

	// Method that sets the pause menu ingame to active and Sets the timescale to 0
	public void Pause(){
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		GamePaused = true;
	}

	// Method that sets the pause menu ingame to inactive and resumes the timescale
	public void Resume(){
		pauseMenu.SetActive(false);
		highScoreMenu.SetActive(false);
		optionsMenu.SetActive(false);
		Time.timeScale = 1f;
		GamePaused = false;
	}

	// Method that opens the options overlay
	public void Options(){
		optionsMenu.SetActive(true);
		pauseMenu.SetActive(false);
	}

	//Method that displays the high score menu
	public void HighScores(){
		highScoreMenu.SetActive(true);
		pauseMenu.SetActive(false);
	}

	//Method that brings the user back to the pause menu
	public void Back(){
		highScoreMenu.SetActive(false);
		optionsMenu.SetActive(false);
		pauseMenu.SetActive(true);
	}

	//Method that toggles the game music
	public void toggleMusic(){
		audioCheck = !audioCheck;
		if(audioCheck){
			AudioListener.pause = true;
		}
		else{
			AudioListener.pause = false;
		}
	}
	
	//Method that toggles the fullscreen
	public void toggleFullscreen(){
		Screen.fullScreen = !Screen.fullScreen;
	}

	// Method that is called when the Main Menu button is pressed in the pause menu.
	public void MainMenu(){
		//Resume the timescale for when the level is reloaded
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}
}
