using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Move : MonoBehaviour {

    public int speed = 10;
    public int jump = 1250;
    public int health = 3;
    public float timeLeft = 5;
    private float moveXPos;
    private int jumpCount = 0;
    private bool powerUpCheck = false;
    public Sprite[] hearts;

    // Update is called once per frame
    void Update () {
        PlayerMove ();

        if(powerUpCheck == true){
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0.1f){
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
                powerUpCheck = false;
                timeLeft = 5;
            }
        }
	}

    void PlayerMove()
    {
        //Controls
        moveXPos = Input.GetAxis("Horizontal");
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
        //Player Direction
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

    void Jump()
    {
        //Code to jump
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump);
    }

    void OnCollisionEnter2D (Collision2D col){
        if(col.gameObject.tag == "ground"){
            jumpCount = 0;
        }

        if(col.gameObject.tag == "Enemy"){
            if(powerUpCheck == true){
                Destroy(col.gameObject);
            }
            else{
                health--;
                if(health == 2){
                    hearts[0] = hearts[1];
                }
                Debug.Log(health);
                if(health == 0){
                    SceneManager.LoadScene("Level_1");
                }
            }
        }

        if(col.gameObject.tag == "Waste"){
			GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 1);
            powerUpCheck = true;
		}
    } 
}
