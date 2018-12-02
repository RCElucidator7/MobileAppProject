using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Level_End : MonoBehaviour {


	private float timeLeft = 0;
	private float timeLimit = 180;
	public int playerScore = 0;
	public bool EndCheck = false;
	public GameObject timeLeftUI;
	public GameObject playerScoreUI;
	
	/*void Start () {
		Data_Management.dataManagement.LoadData();
	}*/

	// Update is called once per frame
	void Update () {
		// Decreases the time every second
		timeLeft += Time.deltaTime;
		// Updates the time on the GUI
		timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
		playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
		// If the timer goes below 0 put the player back to the main menu
		if(timeLeft >= timeLimit){
			SceneManager.LoadScene("MainMenu");
		}
	}

	void CountScore(){
		//Takes the score by taking the time of completion and multiplying it by 10
		playerScore = playerScore + (int)(timeLeft * 10);
		//Data_Management.dataManagement.highScore = playerScore + (int)(timeLeft * 10);
		//Data_Management.dataManagement.SaveData();
	}

	void OnTriggerEnter2D (Collider2D trig){
		// If the player hits the end of the first level, load the next level
		if(trig.gameObject.name == "Level_End"){
			EndCheck = true;
			CountScore();
			//Data_Management.dataManagement.SaveData();
			//SceneManager.LoadScene("Level_2");
		}
		// If the player hits the end of the second level, load the next level
		if(trig.gameObject.name == "Level_End2"){
			EndCheck = true;
			CountScore();
			//Data_Management.dataManagement.SaveData();
			SceneManager.LoadScene("Level_3");
		}
		// If the player hits the end of the third level, load the next level
		if(trig.gameObject.name == "Level_End3"){
			EndCheck = true;
			CountScore();
			//Data_Management.dataManagement.SaveData();
			SceneManager.LoadScene("Level_4");
		}
		// If the player hits the end of the forth level, load the next level
		if(trig.gameObject.name == "Level_End4"){
			EndCheck = true;
			CountScore();
			//Data_Management.dataManagement.SaveData();
			SceneManager.LoadScene("Level_5");
		}
		// If the player hits the end of the fifth level, load the main menu
		if(trig.gameObject.name == "Level_End5"){
			EndCheck = true;
			CountScore();
			//Data_Management.dataManagement.SaveData();
			SceneManager.LoadScene("MainMenu");
		}
	}
}
