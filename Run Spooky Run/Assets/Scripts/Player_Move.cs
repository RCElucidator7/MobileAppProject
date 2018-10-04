using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public int speed = 10;
    private bool faceRight = false;
    public int jump = 1250;
    private float moveXPos;
	
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
            Jump();
        }
        //Player Direction
        if(moveXPos < 0.0f && faceRight == false)
        {
            FlipPlayer();
        }
        else if (moveXPos > 0.0f && faceRight == true)
        {
            FlipPlayer();
        }

        //Game Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveXPos * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //Code to jump
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump);

    }

    void FlipPlayer()
    {
        faceRight = !faceRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
