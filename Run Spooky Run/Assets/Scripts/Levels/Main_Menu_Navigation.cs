using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Menu_Navigation : MonoBehaviour {

	public int[] scores = new int[5];
	public int score5;
	public GameObject options;
	public GameObject highScores;
	public GameObject levelSelect;
	public GameObject mainMenu;
	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	public GameObject level4;
	public GameObject level5;
	public GameObject[] levelStars = new GameObject[5];
	public Sprite star1;
    public Sprite star2;
    public Sprite star3;
	public bool audioCheck = true;

	void Start () {
		scores[0] = PlayerPrefs.GetInt ("highScore1", 0);
		scores[1] = PlayerPrefs.GetInt ("highScore2", 0);
		scores[2] = PlayerPrefs.GetInt ("highScore3", 0);
		scores[3] = PlayerPrefs.GetInt ("highScore4", 0);
		//Having an issue with the 5th position in the array so storing in a single variable
		score5 = PlayerPrefs.GetInt ("highScore5", 0);
	}

	void Update () {
		level1.gameObject.GetComponent<Text>().text = ("Level 1: " + scores[0]);
		level2.gameObject.GetComponent<Text>().text = ("Level 2: " + scores[1]);
		level3.gameObject.GetComponent<Text>().text = ("Level 3: " + scores[2]);
		level4.gameObject.GetComponent<Text>().text = ("Level 4: " + scores[3]);
		//Having an issue with the 5th position in the array so storing in a single variable
		level5.gameObject.GetComponent<Text>().text = ("Level 5: " + score5);

		for(int i = 0; i < 3; i++){
			//Checks for the fifth level
			if(score5 > 500){
				levelStars[4].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star1;
			}
			if(score5 > 500){
				levelStars[4].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star2;
			}
			if(score5 > 500){
				levelStars[4].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star3;
			}

			//Checks for levels 1-4
			if(scores[i] > 500){
				levelStars[i].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star1;
			}
			if(scores[i] > 1000){
				levelStars[i].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star2;
			}
			if(scores[i] > 1500){
				levelStars[i].gameObject.GetComponentInChildren<SpriteRenderer>().sprite = star3;
			}
		}
	}

	public void playGame () {
		levelSelect.SetActive(true);
		mainMenu.SetActive(false);
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

	public void highScoreMenu(){
		mainMenu.SetActive(false);
		highScores.SetActive(true);
	}

	public void toggleFullscreen(){
		Debug.Log("Fullscreen Toggled");
		Screen.fullScreen = !Screen.fullScreen;
	}

	public void backButton(){
		options.SetActive(false);
		highScores.SetActive(false);
		mainMenu.SetActive(true);
	}

		public void levelOneButton () {
		SceneManager.LoadScene("Level_1");
	}

	public void levelTwoButton () {
		if(scores[0] != 0){
			SceneManager.LoadScene("Level_2");
		}
	}

	public void levelThreeButton () {
		if(scores[1] != 0){
			SceneManager.LoadScene("Level_3");
		}
	}

	public void levelFourButton () {
		if(scores[2] != 0){
			SceneManager.LoadScene("Level_4");
		}
	}

	public void levelFiveButton () {
		if(scores[3] != 0){
			SceneManager.LoadScene("Level_5");
		}
	}
}
