using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu_Navigation : MonoBehaviour {

	//Variables to store the scores locally
	public int[] scores = new int[5];
	public int score5;
	//Game objects to access the overlays
	public GameObject options;
	public GameObject highScores;
	public GameObject levelSelect;
	public GameObject mainMenu;
	//Game objects to access the level scores on the high score menu
	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	public GameObject level4;
	public GameObject level5;
	//Array of objects for the star sprites in the level select
	public GameObject[] levelStars = new GameObject[5];
	//Sprite variables to store each star value
	public Sprite star1;
    public Sprite star2;
    public Sprite star3;
	//Audiocheck for game music
	public bool audioCheck = true;

	void Start () {
		//Get the scores from the PlayerPrefs and assign them to high score variables
		scores[0] = PlayerPrefs.GetInt ("highScore1", 0);
		scores[1] = PlayerPrefs.GetInt ("highScore2", 0);
		scores[2] = PlayerPrefs.GetInt ("highScore3", 0);
		scores[3] = PlayerPrefs.GetInt ("highScore4", 0);
		//Having an issue with the 5th position in the array so storing in a single variable
		score5 = PlayerPrefs.GetInt ("highScore5", 0);
	}

	void Update () {
		//Access the level game objects in the high score menu and display the scores
		level1.gameObject.GetComponent<Text>().text = ("Level 1: " + scores[0]);
		level2.gameObject.GetComponent<Text>().text = ("Level 2: " + scores[1]);
		level3.gameObject.GetComponent<Text>().text = ("Level 3: " + scores[2]);
		level4.gameObject.GetComponent<Text>().text = ("Level 4: " + scores[3]);
		//Having an issue with the 5th position in the array so storing in a single variable
		level5.gameObject.GetComponent<Text>().text = ("Level 5: " + score5);

		//Loop through each value in the level array and check if the scores exceed the given values
		// If they do then a star is assigned accordingly
		for(int i = 0; i < 3; i++){
			//Checks for the fifth level
			if(score5 > 500){
				levelStars[4].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star1;
			}
			if(score5 > 750){
				levelStars[4].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star2;
			}
			if(score5 > 1200){
				levelStars[4].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star3;
			}

			//Checks for levels 1-4
			if(scores[i] > 500){
				levelStars[i].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star1;
			}
			if(scores[i] > 750){
				levelStars[i].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star2;
			}
			if(scores[i] > 1200){
				levelStars[i].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star3;
			}
		}
	}

	//Method that displays the level select overlay
	public void playGame () {
		levelSelect.SetActive(true);
		mainMenu.SetActive(false);
	}

	//Method that quits the application
	public void quitOption () {
		Debug.Log("Quitting Application");
		Application.Quit();
	}

	//Method that opens the options overlay where the user can access fullscreen and music toggle
	public void optionsMenu(){
		mainMenu.SetActive(false);
		options.SetActive(true);
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

	//Method that displays the high score menu
	public void highScoreMenu(){
		mainMenu.SetActive(false);
		highScores.SetActive(true);
	}

	//Method that brings the user back to the main menu
	public void backButton(){
		levelSelect.SetActive(false);
		options.SetActive(false);
		highScores.SetActive(false);
		mainMenu.SetActive(true);
	}

	//Method that Launches level 1
	public void levelOneButton () {
		SceneManager.LoadScene("Level_1");
	}

	//Method that Launches level 2 assuming the user has completed the previous level
	public void levelTwoButton () {
		if(scores[0] != 0){
			SceneManager.LoadScene("Level_2");
		}
	}

	//Method that Launches level 3 assuming the user has completed the previous level
	public void levelThreeButton () {
		if(scores[1] != 0){
			SceneManager.LoadScene("Level_3");
		}
	}

	//Method that Launches level 4 assuming the user has completed the previous level
	public void levelFourButton () {
		if(scores[2] != 0){
			SceneManager.LoadScene("Level_4");
		}
	}

	//Method that Launches level 5 assuming the user has completed the previous level
	public void levelFiveButton () {
		if(scores[3] != 0){
			SceneManager.LoadScene("Level_5");
		}
	}
}
