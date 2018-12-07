using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Move : MonoBehaviour {

    public int speed = 10;
    public int jump = 1250;
    public int health = 4;
    public float timeLeft = 5;
    private float moveXPos;
    private int jumpCount = 0;
    private bool powerUpCheck = false;

    // Update is called once per frame
    void Update () {
        PlayerMove ();

        // Check if the power up is active
        if(powerUpCheck == true){
            //Set a 5 second timer where the player is temporarly invincible
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0.1f){
                //After the 5 seconds, remove invincibility and set the characters colour back
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
                powerUpCheck = false;
                timeLeft = 5;
            }
        }
	}

    //Main function that controls the players movements
    void PlayerMove()
    {
        //Controls
        moveXPos = Input.GetAxis("Horizontal");
        //Checks if the player has jumped, and cannot jump again after two jumps
        if (Input.GetButtonDown("Jump"))
        {
            if(jumpCount > 1){
                // Can't Jump
            }
            else{
                Jump();
                jumpCount++;
            }
        }
        //Player Direction: Changes the players direction based on which way they are facing
        if(moveXPos < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveXPos > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //Game Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveXPos * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    //Code to jump
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump);
    }

    // Detects whenever the player comes into contact with certain objects
    void OnCollisionEnter2D (Collision2D col){
        //If the players hits the ground, reset the jump counter
        if(col.gameObject.tag == "ground"){
            jumpCount = 0;
        }

        //If the Player collides with the enemy, either lose health or destroy the enemy depending on if the player is invincible or not
        if(col.gameObject.tag == "Enemy"){
            //If the player is powered up, Destory the enemy
            if(powerUpCheck == true){
                Destroy(col.gameObject);
            }
            else{
                //Decrement health
                health--;
            }
        }

        //If the player collides with the spikes, lose health unless invincible
        if(col.gameObject.tag == "Spike"){
            if(powerUpCheck == true){
                // Do no damage
            }
            else{
                jumpCount = 0;
                health--;
            }
        }

        //If the player collides with the Waste pickup, grant temporary invincibility 
        if(col.gameObject.tag == "Waste"){
			GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 1);
            powerUpCheck = true;
            Destroy(col.gameObject);
		}
    }
}
