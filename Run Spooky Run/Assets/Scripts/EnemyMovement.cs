using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour {

	public int enemySpeed;
	public int range;
	public bool isDead = false;

	//public int xDir;

	private Transform target;
	
	void Start (){
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {

		if(Vector2.Distance(transform.position, target.position) < range){
			//Move towards method parameters
			//(MoveFrom, MoveTo, AtWhatSpeed)
			transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
		}



		/*RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xDir, 0));
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xDir, 0) * enemySpeed;
		if(hit.distance < 0.7f){
			Flip ();
		}*/
	if(gameObject.transform.position == target.position && isDead == false)
        {
            Debug.Log("Player has Died");
            isDead = true;

            if(isDead == true)
            {
                StartCoroutine ("Die");
            }
        }
	}

    IEnumerator Die ()
    {
        SceneManager.LoadScene ("Level_1");
        yield return null;
    }

	/*void Flip (){
		if (xDir > 0){
			xDir = -1;
		}
		else {
			xDir = 1;
		}
	}*/
}
