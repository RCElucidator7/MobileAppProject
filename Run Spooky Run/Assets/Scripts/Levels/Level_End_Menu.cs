using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_End_Menu : MonoBehaviour {

	public GameObject levelEndMenu;
	public bool End_Check;
	public Level_End LE;
	public int[] scores = new int[5];
	public int score5;
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
		//Set the local health to the characters health
		End_Check = LE.EndCheck;
		// Checks to see if the escape key is pressed
		if(End_Check){
			LevelEnd();
		}

		//Access the level game objects in the high score menu and display the scores
		level1.gameObject.GetComponent<Text>().text = ("Level 1: " + scores[0]);
		level2.gameObject.GetComponent<Text>().text = ("Level 2: " + scores[1]);
		level3.gameObject.GetComponent<Text>().text = ("Level 3: " + scores[2]);
		level4.gameObject.GetComponent<Text>().text = ("Level 4: " + scores[3]);
		//Having an issue with the 5th position in the array so storing in a single variable
		level5.gameObject.GetComponent<Text>().text = ("Level 5: " + score5);
	}

	// Function that sets the pause menu ingame to active and Sets the timescale to 0
	public void LevelEnd(){
		levelEndMenu.SetActive(true);
		Time.timeScale = 0f;
		LE.EndCheck = false;
	}

	// Function that sets the pause menu ingame to inactive and resumes the timescale
	public void Next_Level(){
		levelEndMenu.SetActive(false);
		Time.timeScale = 1f;
		Scene scene = SceneManager.GetActiveScene();
 		if(scene.name == "Level_1"){
			SceneManager.LoadScene("Level_2");
		}
		// If the player hits the end of the second level, load the next level
		if(scene.name == "Level_2"){
			SceneManager.LoadScene("Level_3");
		}
		// If the player hits the end of the third level, load the next level
		if(scene.name == "Level_3"){
			SceneManager.LoadScene("Level_4");
		}
		// If the player hits the end of the forth level, load the next level
		if(scene.name == "Level_4"){
			SceneManager.LoadScene("Level_5");
		}
		// If the player hits the end of the fifth level, load the main menu
		if(scene.name == "Level_5"){
			SceneManager.LoadScene("MainMenu");
		}
	}

	// Function that is called when the Main Menu button is pressed in the pause menu.
	public void MainMenu(){
		//Resume the timescale for when the level is reloaded
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
	}
}
