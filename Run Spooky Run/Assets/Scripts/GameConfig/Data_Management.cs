using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Data_Management : MonoBehaviour {

	public static PlayerScore ps;

	void Start () {
		//Keep the data on all scenes and load that data
		DontDestroyOnLoad(gameObject);
        LoadData();
	}
	
	//Saves the players scores on each level
	public void SaveData () {
		PlayerPrefs.SetInt("highScore1", ps.highScore1);
		PlayerPrefs.SetInt("highScore2", ps.highScore2);
		PlayerPrefs.SetInt("highScore3", ps.highScore3);
		PlayerPrefs.SetInt("highScore4", ps.highScore4);
		PlayerPrefs.SetInt("highScore5", ps.highScore5);
	}

	//Loads the players data
	public void LoadData () {
		//New instance of PlayerScore
		ps = new PlayerScore();

		//If there is a high score for each value, then get that value and store it here
		if(PlayerPrefs.HasKey("highScore1")){
			ps.highScore1 = PlayerPrefs.GetInt ("highScore1");
		}
		else if(PlayerPrefs.HasKey("highScore2")){
			ps.highScore2 = PlayerPrefs.GetInt ("highScore2");
		}
		else if(PlayerPrefs.HasKey("highScore3")){
			ps.highScore3 = PlayerPrefs.GetInt ("highScore3");
		}
		else if(PlayerPrefs.HasKey("highScore4")){
			ps.highScore4 = PlayerPrefs.GetInt ("highScore4");
		}
		else if(PlayerPrefs.HasKey("highScore5")){
			ps.highScore5 = PlayerPrefs.GetInt ("highScore5");
		}
	}

	//Save the new high scores if it is higher than the previous score
	public void setScore(int score, int level){
		if(level == 1){
			if(score >= ps.highScore1){
				ps.highScore1 = score;
				SaveData();
			}
		}
		else if(level == 2){
			if(score >= ps.highScore2){
				ps.highScore2 = score;
				SaveData();
			}
		}
		else if(level == 3){
			if(score >= ps.highScore3){
				ps.highScore3 = score;
				SaveData();
			}
		}
		else if(level == 4){
			if(score >= ps.highScore4){
				ps.highScore4 = score;
				SaveData();
			}
		}
		else if(level == 5){
			if(score >= ps.highScore5){
				ps.highScore5 = score;
				SaveData();
			}
		}
	}

	//Returns the high score
	public int getScore(){
		return ps.highScore1;
	}
}
