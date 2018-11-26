using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Check : MonoBehaviour {

	public Sprite heart3;
    public Sprite heart2;
    public Sprite heart1;
    public Sprite heart0;
	public int health_Check;
	public Player_Move pm;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Set the local health to the characters health
		health_Check = pm.health;
		//if statements to check what the players health is currently, changes heart sprite accordingly
		if(health_Check == 3){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heart3;
			return;
        }
        else if(health_Check == 2){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heart2;
			return;
        }
        else if(health_Check == 1){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heart1;
			return;
        }
        else if(health_Check == 0){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = heart0;
			return;
        }
	}
}
