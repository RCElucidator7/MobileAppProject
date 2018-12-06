using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Data_Management : MonoBehaviour {

	public static PlayerScore ps;
	//public int highScore;

	void Start () {
		DontDestroyOnLoad(gameObject);
        LoadData();
	}
	

	public void SaveData () {
		PlayerPrefs.SetInt("highScore1", ps.highScore1);
		PlayerPrefs.SetInt("highScore2", ps.highScore2);
		PlayerPrefs.SetInt("highScore3", ps.highScore3);
		PlayerPrefs.SetInt("highScore4", ps.highScore4);
		PlayerPrefs.SetInt("highScore5", ps.highScore5);
	}

	public void LoadData () {

		ps = new PlayerScore();

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

	public void setScore(int score, int level){
		Debug.Log(score);
		Debug.Log(level);
		if(level == 1){
			if(score >= ps.highScore1){
				ps.highScore1 = score;
				SaveData();
			}
		}
		else if(level == 2){
			if(score >= ps.highScore2){
				ps.highScore2 = score;
				Debug.Log(ps.highScore2);
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

	public int getScore(){
		return ps.highScore1;
	}
}
