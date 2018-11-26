using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Navigation : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playGame () {
		SceneManager.LoadScene("LevelSelectMenu");
	}

	public void quitOption () {
		Debug.Log("Quitting Application");
		Application.Quit();
	}
}
