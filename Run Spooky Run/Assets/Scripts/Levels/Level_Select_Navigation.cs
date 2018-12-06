using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level_Select_Navigation : MonoBehaviour {

	public Main_Menu_Navigation mmn;
	public Sprite star1;
    public Sprite star2;
    public Sprite star3;
	public int score1;
	public int score2;
	public int score3;
	public int score4;
	public int score5;
	//public Level_End LE;

	void Start () {
		score1 = mmn.scores[0];
		Debug.Log(score1);
	}

	// Update is called once per frame
	void Update () {
		//Set the local health to the characters health
		//score1 = LE.playerScore;
		//if statements to check what the players health is currently, changes heart sprite accordingly
		if(score1 > 0){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = star1;
			return;
        }
        else if(score1 > 500){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = star2;
			return;
        }
        else if(score1 > 1000){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = star3;
			return;
        }
	}
	public void levelOneButton () {
		SceneManager.LoadScene("Level_1");
	}

	public void levelTwoButton () {
		if(score1 != 0){
			SceneManager.LoadScene("Level_2");
		}
	}

	public void levelThreeButton () {
		if(score2 != 0){
			SceneManager.LoadScene("Level_3");
		}
	}

	public void levelFourButton () {
		if(score3 != 0){
			SceneManager.LoadScene("Level_4");
		}
	}

	public void levelFiveButton () {
		if(score4 != 0){
			SceneManager.LoadScene("Level_5");
		}
	}
}
