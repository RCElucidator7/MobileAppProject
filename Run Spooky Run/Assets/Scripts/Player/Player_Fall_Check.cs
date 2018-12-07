using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Fall_Check : MonoBehaviour {

    public bool isDead;

	// Use this for initialization
	void Start () {
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        //If the player falls below a certain position restart the levels
		if(gameObject.transform.position.y < -7 && isDead == false)
        {
            isDead = true;
            if(isDead == true)
            {
                Dead();
            }
        }
	}

    //Calls once the player has died
    public void Dead ()
    {
        //Get the current scene and reload the scene
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
