using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour {

	public int enemySpeed;
	public int range;
	private float moveXPos;
	private Transform target;
	
	void Start (){
		//Find where the player is
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		// If the player comes within the enemy range, the enemy follows the player
		if(Vector2.Distance(transform.position, target.position) < range){
			//Move towards method parameters
			moveXPos = Input.GetAxis("Horizontal");
			//(MoveFrom, MoveTo, AtWhatSpeed)
			transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
		}

		//Player Direction
		if(moveXPos > 0.0f)
		{
			GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (moveXPos < 0.0f)
		{
			GetComponent<SpriteRenderer>().flipX = false;
		}
	}
}