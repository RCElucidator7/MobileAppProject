using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public int enemySpeed;
	public int xDir;
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xDir, 0));
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xDir, 0) * enemySpeed;
		if(hit.distance < 1.7f){
			Flip ();
		}
	}

	void Flip (){
		if (xDir > 0){
			xDir = -1;
		}
		else {
			xDir = 1;
		}
	}
}
