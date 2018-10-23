﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Level_End : MonoBehaviour {


	private float timeLeft = 480;
	public int playerScore = 0;
	private GameObject waste;
	public GameObject timeLeftUI;
	public GameObject playerScoreUI;
	
	void Start () {
		Data_Management.dataManagement.LoadData();
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
		playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
		if(timeLeft < 0.1f){
			SceneManager.LoadScene("Level_1");
		}
	}

	void CountScore(){
		playerScore = playerScore + (int)(timeLeft * 10);
		Data_Management.dataManagement.highScore = playerScore + (int)(timeLeft * 10);
		Data_Management.dataManagement.SaveData();
	}

	void OnTriggerEnter2D (Collider2D trig){
		Debug.Log("Hit end");
		if(trig.gameObject.name == "Level_End"){
			CountScore();
			Data_Management.dataManagement.SaveData();
			//SceneManager.LoadScene("Level_2");
		}

		if(trig.gameObject.name == "Waste"){
			playerScore += 100;
			Destroy (trig.gameObject);
		}
	}
}
