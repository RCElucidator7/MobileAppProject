using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Fall_Check : MonoBehaviour {

    public int health;
    public bool isDead;

	// Use this for initialization
	void Start () {
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.y < -7 && isDead == false)
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
}
