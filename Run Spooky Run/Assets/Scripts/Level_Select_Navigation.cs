using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level_Select_Navigation : MonoBehaviour {

	public void levelOneButton () {
		SceneManager.LoadScene("Level_1");
	}

	public void levelTwoButton () {
		SceneManager.LoadScene("Level_2");
	}

	public void levelThreeButton () {
		SceneManager.LoadScene("Level_3");
	}

	public void levelFourButton () {
		SceneManager.LoadScene("Level_4");
	}

	public void levelFiveButton () {
		SceneManager.LoadScene("Level_5");
	}
}
