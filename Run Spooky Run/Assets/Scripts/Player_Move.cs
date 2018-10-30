using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public int speed = 10;
    public int jump = 1250;
    private float moveXPos;
    private int jumpCount = 0;

    // Update is called once per frame
    void Update () {
        PlayerMove ();
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
    } 
}
